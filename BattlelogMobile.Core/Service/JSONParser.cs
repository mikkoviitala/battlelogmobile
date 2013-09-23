using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using BattlelogMobile.Core.Message;
using BattlelogMobile.Core.Model;
using BattlelogMobile.Core.Repository;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattlelogMobile.Core.Service
{
    public class JSONParser : IJSONParser<ISoldier>
    {
        private readonly IsolatedStorageFile _isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        private readonly IImageRepository _imageRepository = new ImageRepository();

        /// <summary>
        /// Here lies some nasty JSON parsing...
        /// </summary>
        /// <returns></returns>
        public ISoldier Parse()
        {
            IsolatedStorageFileStream resource = null;
            
            try
            {
                resource = _isolatedStorage.OpenFile(Common.OverviewFile, FileMode.Open);
                var streamReader = new StreamReader(resource);
            
                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");
                var overviewStatsToken = dataToken.SelectToken("overviewStats");

                ISoldier soldier = ParseSoldier(overviewStatsToken);
                soldier.User = ParseUser(dataToken.SelectToken("user"));

                var serviceStars = ParseServiceStars(overviewStatsToken.SelectToken("serviceStars"));
                soldier.KitProgressions = ParseKitServiceStarProgressions(overviewStatsToken.SelectToken("serviceStarsProgress"), serviceStars).ToList();
                soldier.Score = ParseScore(overviewStatsToken);
                soldier.Score.Kits = ParseKitScore(overviewStatsToken).ToList();
                soldier.Awards = ParseAwards(dataToken.SelectToken("awards")).ToList();
                soldier.Statistics = ParseStatistics(dataToken.SelectToken("overviewStats"));

                soldier.Vehicles = ParseVehicles(Common.VehiclesFile).ToList();
                soldier.Weapons = ParseWeapons(Common.WeaponsAndGadgetsFile).ToList();
                soldier.Gadgets = ParseGadgets(Common.WeaponsAndGadgetsFile).ToList();
                //soldier.Unlocks = ParseUnlocks(Common.UnlocksFile);

                return soldier;
            }
            catch (Exception e)
            {
                if (e is JsonReaderException || e is IOException || e is ArgumentException || e is FormatException || e is NullReferenceException)
                    Messenger.Default.Send(new BattlelogResponseMessage(Common.JsonParseFailedMessage, false));
                else
                    throw;
                return null;
            }
            finally
            {
                if (resource != null)
                    resource.Close();
            }
        }

        // Kit scores, usage time and usage percentage
        //private IKits ParseKitScore(JToken scoreToken)
        private IEnumerable<IKit> ParseKitScore(JToken scoreToken)
        {
            var kits = new List<IKit>();
            // Kit score
            foreach (var kit in scoreToken.SelectToken("kitScores"))
            {
                string[] parts = kit.ToString().Split(':');
                var kitType = (KitType)Convert.ToInt32(parts[0].Substring(parts[0].IndexOf('"') + 1, parts[0].LastIndexOf('"') - 1));

                int kitScore = 0;
                if (parts[1].Contains("\""))
                    kitScore = Convert.ToInt32(parts[1].Substring(parts[1].IndexOf('"') + 1, parts[1].LastIndexOf('"') - 2));
                
                string kitImage = kitType.ToString().ToLowerInvariant() + Common.ImageSuffix;

                var k = new Kit() { Type = kitType, Score = kitScore, ImageName = kitImage };
                _imageRepository.Load(Common.KitImageUrl, kitImage, bitmap => { k.Image = bitmap; });
                kits.Add(k);   
            }

            // Do very unique, custom sort ;)
            kits.Sort((p1, p2) =>
                string.CompareOrdinal(
                    ((int)p1.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1),
                        ((int)p2.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1)));

            // Kit usage times
            foreach (var kit in scoreToken.SelectToken("kitTimes"))
            {
                string[] parts = kit.ToString().Split(':');
                var kitType = (KitType)Convert.ToInt32(parts[0].Substring(parts[0].IndexOf('"') + 1, parts[0].LastIndexOf('"') - 1));

                TimeSpan kitTime = TimeSpan.FromSeconds(0);
                if (parts[1].Contains("\""))
                    kitTime = TimeSpan.FromSeconds(
                        Convert.ToDouble(parts[1].Substring(parts[1].IndexOf('"') + 1, parts[1].LastIndexOf('"') - 2), CultureInfo.InvariantCulture));
                (kits.First(kitScore => kitScore.Type == kitType)).Time = kitTime;
            }

            // Kit usage percentage
            foreach (var kit in scoreToken.SelectToken("kitTimesInPercentage"))
            {
                string[] parts = kit.ToString().Split(':');
                var kitType = (KitType)Convert.ToInt32(parts[0].Substring(parts[0].IndexOf('"') + 1, parts[0].LastIndexOf('"') - 1));
                var kitPercentage = Convert.ToDouble(parts[1], CultureInfo.InvariantCulture);
                (kits.First(kitScore => kitScore.Type == kitType)).Percentage = kitPercentage;
            }
            //return new Kits(kits);
            return kits;
        }

        // Total score and "generic" multiplayer scores
        private IScore ParseScore(JToken scoreToken)
        {
            IScore score = new Score();
            int totalScore = Convert.ToInt32(scoreToken.SelectToken("totalScore").ToString());
            score.TotalScore = totalScore;

            var others = new List<IOther>()
                    {
                        new Other("Vehicles", Convert.ToInt32(scoreToken.SelectToken("sc_vehicle").ToString())), 
                        new Other("Combat", Convert.ToInt32(scoreToken.SelectToken("combatScore").ToString())),
                        new Other("Awards", Convert.ToInt32(scoreToken.SelectToken("sc_award").ToString())),
                        new Other("Unlocks", Convert.ToInt32(scoreToken.SelectToken("sc_unlock").ToString()))
                    };
            
            score.Others = others;
            return score;
        }

        // Combine earned stars and current progress
        //private IKitProgressions ParseKitServiceStarProgressions(IEnumerable<JToken> kitServiceStarProgressToken, List<KeyValuePair<KitType, int>> serviceStars)
        private IEnumerable<IKitProgression> ParseKitServiceStarProgressions(IEnumerable<JToken> kitServiceStarProgressToken, List<KeyValuePair<KitType, int>> serviceStars)
        {
            // Stars and current progress are on different tokens
            var progressions = new List<IKitProgression>();
            foreach (var kitServiceStarProgress in kitServiceStarProgressToken)
            {
                string[] parts = kitServiceStarProgress.ToString().Split(':');
                var kitType = (KitType)Convert.ToInt32(parts[0].Substring(parts[0].IndexOf('"') + 1, parts[0].LastIndexOf('"') - 1));
                double kitProgress = Convert.ToDouble(parts[1], CultureInfo.InvariantCulture);
                
                int numberOfServiceStars = 0;
                foreach (var serviceStar in serviceStars.Where(serviceStar => serviceStar.Key == kitType))
                    numberOfServiceStars = serviceStar.Value;
                
                var kitProgression = new KitProgression(kitType, numberOfServiceStars, kitProgress);
                _imageRepository.Load(Common.ServiceStarImageUrl, Common.ServiceStarImage, bitmap => { kitProgression.Image = bitmap; });
                progressions.Add(kitProgression);
            }
            progressions.Sort((p1, p2) =>
                string.CompareOrdinal(
                    ((int)p1.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1),
                        ((int)p2.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1)));

            //return new KitProgressions(progressions);
            return progressions;
        }

        // Number of service stars
        private List<KeyValuePair<KitType, int>> ParseServiceStars(IEnumerable<JToken> serviceStarsToken)
        {
            var serviceStars = new List<KeyValuePair<KitType, int>>();
            foreach (var serviceStar in serviceStarsToken)
            {
                string[] parts = serviceStar.ToString().Split(':');
                var type = (KitType)Convert.ToInt32(parts[0].Substring(parts[0].IndexOf('"') + 1, parts[0].LastIndexOf('"') - 1));
                int count = Convert.ToInt32(Convert.ToDouble(parts[1], CultureInfo.InvariantCulture));
                serviceStars.Add(new KeyValuePair<KitType, int>(type, count));
            }
            return serviceStars;
        }

        // Basic BF3 soldier information
        private ISoldier ParseSoldier(JToken overviewStatsToken)
        {
            //const string rankFormat = "00";
            ISoldier soldier = new Soldier()
            {
                UpdateTime = DateTime.Now,
                Rank = Convert.ToInt32(overviewStatsToken.SelectToken("rank").ToString()),
                Skill = Convert.ToDouble(overviewStatsToken.SelectToken("elo").ToString()),
                TimePlayed = TimeSpan.FromSeconds(Convert.ToDouble(overviewStatsToken.SelectToken("timePlayed").ToString(), CultureInfo.InvariantCulture)),
                RoundsPlayed = Convert.ToInt32(overviewStatsToken.SelectToken("numRounds").ToString()),
                ScorePerMinute = Convert.ToDouble(overviewStatsToken.SelectToken("scorePerMinute").ToString()),
                KillDeathRatio = Math.Round((Convert.ToDouble(overviewStatsToken.SelectToken("kills").ToString()) / Convert.ToDouble(overviewStatsToken.SelectToken("deaths").ToString())), 2),
                //KillDeathRatio = Convert.ToDouble(overviewStatsToken.SelectToken("kdRatio").ToString()),
                Wins = Convert.ToInt32(overviewStatsToken.SelectToken("numWins").ToString()),
                Losses = Convert.ToInt32(overviewStatsToken.SelectToken("numLosses").ToString())
            };

            string image = soldier.Rank <= Common.MaxRank ?
                    Common.RankImagePrefix + soldier.Rank.ToString(CultureInfo.InvariantCulture) + Common.ImageSuffix :
                    Common.RankServiceStarImagePrefix + (soldier.Rank - Common.MaxRank).ToString(CultureInfo.InvariantCulture) + Common.ImageSuffix;
            soldier.RankImageName = image;
            _imageRepository.Load(Common.RankImageUrl, image, bitmap => { soldier.RankImage = bitmap; });
            return soldier;
        }

        // Battlelog user information
        private IUser ParseUser(JToken userToken)
        {
            IUser user = new User
            {
                Id = Convert.ToInt64(userToken.SelectToken("userId").ToString()),
                Name = userToken.SelectToken("username").ToString(),
                GravatarMd5 = userToken.SelectToken("gravatarMd5").ToString(),
            };

            _imageRepository.Load(Common.GravatarImageUrl, user.GravatarMd5, bitmap => { user.Image = bitmap; });
            return user;
        }

        // Generic statistics
        private IStatistics ParseStatistics(JToken statisticsToken)
        {
            IStatistics statistics = new Statistics
            {
                Kills = Convert.ToInt32(statisticsToken.SelectToken("kills").ToString()),
                Deaths = Convert.ToInt32(statisticsToken.SelectToken("deaths").ToString()),
                KillAssists = Convert.ToInt32(statisticsToken.SelectToken("killAssists").ToString()),
                VehiclesDestroyed = Convert.ToInt32(statisticsToken.SelectToken("vehiclesDestroyed").ToString()),
                VehiclesDestroyedAssists = Convert.ToInt32(statisticsToken.SelectToken("vehiclesDestroyedAssists").ToString()),
                Accuracy = Convert.ToDouble(statisticsToken.SelectToken("accuracy").ToString()), // , CultureInfo.InvariantCulture
                LongestHeadshot = Convert.ToDouble(statisticsToken.SelectToken("longestHeadshot").ToString()), // CultureInfo.InvariantCulture
                KillStreakBonus = Convert.ToInt32(statisticsToken.SelectToken("killStreakBonus").ToString()),
                SquadScoreBonus = Convert.ToInt32(statisticsToken.SelectToken("sc_squad").ToString()),
                Repairs = Convert.ToInt32(statisticsToken.SelectToken("repairs").ToString()),
                Revives = Convert.ToInt32(statisticsToken.SelectToken("revives").ToString()),
                Heals = Convert.ToInt32(statisticsToken.SelectToken("heals").ToString()),
                Resupplies = Convert.ToInt32(statisticsToken.SelectToken("resupplies").ToString()),
                ShotsFired = Convert.ToInt32(statisticsToken.SelectToken("shotsFired").ToString()),
                Quits = Convert.ToDouble(statisticsToken.SelectToken("quitPercentage").ToString()),
                MCOMDefendKills = Convert.ToInt32(statisticsToken.SelectToken("mcomDefendKills").ToString()),
                MCOMDestroyed = Convert.ToInt32(statisticsToken.SelectToken("mcomDestroy").ToString()),
                FlagsCaptured = Convert.ToInt32(statisticsToken.SelectToken("flagCaptures").ToString()),
                FlagsDefended = Convert.ToInt32(statisticsToken.SelectToken("flagDefend").ToString()),
                AvengerKills = Convert.ToInt32(statisticsToken.SelectToken("avengerKills").ToString()),
                SaviorKills = Convert.ToInt32(statisticsToken.SelectToken("saviorKills").ToString()),
                DogtagsTaken = Convert.ToInt32(statisticsToken.SelectToken("dogtagsTaken").ToString()),
                FlagsCapturedCTF = Convert.ToInt32(statisticsToken.SelectToken("flagrunner").ToString()),
                NemesisStreak = Convert.ToInt32(statisticsToken.SelectToken("nemesisStreak").ToString()),
                NemesisKills = Convert.ToInt32(statisticsToken.SelectToken("nemesisKills").ToString()),
                SuppressionAssists = Convert.ToInt32(statisticsToken.SelectToken("suppressionAssists").ToString())
            };
            return statistics;
        }

        // Latest awards (ribbons and medals)
        //private IAwards ParseAwards(IEnumerable<JToken> awardsToken)
        private IEnumerable<IAward> ParseAwards(IEnumerable<JToken> awardsToken)
        {
            var awards = new List<IAward>();
            foreach (var token in awardsToken)
            {
                var award = new Award()
                {
                    Code = token.SelectToken("award").SelectToken("code").ToString(),
                    Group = token.SelectToken("award").SelectToken("awardGroup").ToString()
                };

                string image = token.SelectToken("award").SelectToken("code") + Common.ImageSuffix;
                award.ImageName = image;

                if (string.CompareOrdinal(award.Group, Common.AwardGroup) == 0)
                {
                    award.ImageUrl = Common.RibbonAwardImageUrl;
                    award.ImageSaveName = Common.RibbonAwardSavePrefix + image;
                    _imageRepository.Load(Common.RibbonAwardImageUrl, image, bitmap => { award.Image = bitmap; }, award.ImageSaveName);
                }
                else
                {
                    award.ImageUrl = Common.MedalAwardImageUrl;
                    award.ImageSaveName = Common.MedalAwardSavePrefix + image;
                    _imageRepository.Load(Common.MedalAwardImageUrl, image, bitmap => { award.Image = bitmap; }, award.ImageSaveName);
                }
                awards.Add(award);
            }
            //return new Awards(awards);
            return awards;
        }

        // Vehicles (in another file)
        //private IItems ParseVehicles(string file)
        private IEnumerable<IItem> ParseVehicles(string file)
        {
            var vehicles = new List<IItem>();
            string completeJson;
            
            //var resource = System.Windows.Application.GetResourceStream(new Uri("JSON/demo_vehicles.txt", UriKind.Relative)).Stream;
            var resource = _isolatedStorage.OpenFile(file, FileMode.Open);
            using(var streamReader = new StreamReader(resource))
            {
                completeJson = streamReader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(completeJson);

            foreach (var vehiclesToken in jObject.SelectToken("data").SelectToken("mainVehicleStats"))
            {
                string guid = vehiclesToken.SelectToken("guid").ToString();
                var vehicle = new Item()
                {
                    Name = vehiclesToken.SelectToken("name").ToString().ToUpperInvariant(),
                    Slug = (vehiclesToken.SelectToken("slug").ToString()).ToUpperInvariant(),
                    Kills = Convert.ToInt32(vehiclesToken.SelectToken("kills").ToString()),
                    TimeIn = TimeSpan.FromSeconds(Convert.ToInt32(vehiclesToken.SelectToken("timeIn").ToString()))
                };
                string image = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("vehicles").SelectToken(guid).SelectToken("image") + Common.ImageSuffix;
                vehicle.ImageName = image;
                _imageRepository.Load(Common.VehicleAndGadgetImageUrl, image, bitmap => { vehicle.Image = bitmap; });
                vehicles.Add(vehicle);
            }
            var sortedAndFiltered = vehicles.OrderByDescending(v => v.Kills).ThenByDescending(v => v.TimeIn).
                ThenBy(v => v.Slug).ThenBy(v => v.Name).Where(g => g.Kills > 0);
            
            //return new Items(sortedAndFiltered.ToList());
            return sortedAndFiltered;
        }

        // Gadgets (in another file)
        //private IItems ParseGadgets(string file)
        private IEnumerable<IItem> ParseGadgets(string file)
        {
            var gadgets = new List<IItem>();
            string completeJson;

            using (var reader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
            {
                completeJson = reader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(completeJson);

            foreach (var gadgetsToken in jObject.SelectToken("data").SelectToken("mainItemStats"))
            {
                string guid = gadgetsToken.SelectToken("guid").ToString();
                var gadget = new Item()
                {
                    Name = gadgetsToken.SelectToken("slug").ToString(),
                    Slug = (gadgetsToken.SelectToken("slug").ToString()).ToUpperInvariant(),
                    // -1 indicates to converter that this option is not possible for this item
                    // actual kill/performance values are parsed below
                    Kills = -1,         
                    Performance = -1
                };

                if (gadgetsToken.SelectToken("performances").HasValues)
                {
                    foreach (var token in gadgetsToken.SelectToken("performances"))
                    {
                        int amount = Convert.ToInt32(token.SelectToken("stat").ToString());
                        string unit = token.SelectToken("name").ToString();

                        if (unit.Equals(Common.KillsToken, StringComparison.OrdinalIgnoreCase))
                        {
                            gadget.Kills = amount;
                        }
                        else
                        {
                            gadget.Performance = amount;
                            gadget.PerformanceDescription = unit;
                        }
                    }
                }

                string image = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("kititems").SelectToken(guid).SelectToken("image") + Common.ImageSuffix;
                gadget.ImageName = image;
                _imageRepository.Load(Common.VehicleAndGadgetImageUrl, image, bitmap => { gadget.Image = bitmap; });
                gadgets.Add(gadget);
            }
            var sortedAndFiltered = gadgets.OrderByDescending(
                g => g.Kills >= g.Performance ? g.Kills : g.Performance).ThenBy(g => g.Slug).ThenBy(g => g.Name); 
            
            //return new Items(sortedAndFiltered);
            return sortedAndFiltered;
        }

        // Weapons
        //private IItems ParseWeapons(string file)
        private IEnumerable<IItem> ParseWeapons(string file)
        {
            var weapons = new List<IItem>();
            string completeJson;

            using (var reader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
            {
                completeJson = reader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(completeJson);

            foreach (var weaponsToken in jObject.SelectToken("data").SelectToken("mainWeaponStats"))
            {
                int kills = Convert.ToInt32(weaponsToken.SelectToken("kills").ToString());
                if (kills == 0)
                    continue;

                var weapon = new Item()
                {
                    Name = weaponsToken.SelectToken("name").ToString().ToUpperInvariant(),
                    Slug = weaponsToken.SelectToken("slug").ToString().ToUpperInvariant(),
                    Kills = kills,
                    Headshots = Convert.ToInt32(weaponsToken.SelectToken("headshots").ToString().ToUpperInvariant()),
                    ServiceStars = Convert.ToInt32(weaponsToken.SelectToken("serviceStars").ToString()),
                    ShotsFired = Convert.ToInt32(weaponsToken.SelectToken("shotsFired").ToString()),
                    Accuracy = Convert.ToDouble(weaponsToken.SelectToken("accuracy").ToString()) * 100d
                };

                string guid = weaponsToken.SelectToken("guid").ToString();
                string image = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("weapons").SelectToken(guid).SelectToken("image") + Common.ImageSuffix;
                weapon.ImageName = image;
                //if (!image.Contains(AmericanImageSuffix) && (!image.Contains(RussianImageSuffix)) && !_duplicateWeaponSlugs.Contains(weapon.Slug))
                //{
                _imageRepository.Load(Common.ServiceStarImageUrl, Common.ServiceStarImage, bitmap => { weapon.ServiceStarImage = bitmap; });
                _imageRepository.Load(Common.WeaponAndAccessoryImageUrl, image, bitmap => { weapon.Image = bitmap; });
                weapons.Add(weapon);
                //}
            }
            var sortedAndFiltered = weapons.OrderByDescending(g => g.Kills).
                ThenByDescending(g => g.Headshots).ThenBy(g => g.Slug).ThenBy(g => g.Name).
                    Where(g => g.Kills > 0);

            // For some reason e.g. M39EMR is twice is JSON ?
            //return new Items(sortedAndFiltered.Distinct(new ItemComparer()).ToList());
            return sortedAndFiltered.Distinct(new ItemComparer()).ToList();
        }

        //private IUnlocks ParseUnlocks(string file)
        //{
        //    var unlocks = new List<IUnlock>();
        //    string completeJson;

        //    using (var reader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
        //    {
        //        completeJson = reader.ReadToEnd();
        //        reader.Close();
        //    }
        //    JObject jObject = JObject.Parse(completeJson);

        //    // [0].SelectToken("weaponAddonUnlock").SelectToken("unlockedBy").SelectToken("completion").ToString()
        //    foreach (var unlocksToken in jObject.SelectToken("data").SelectToken("unlocks"))
        //    {
        //         // check if weaponunlock == null tai weaponaddonunlock == null
                
        //        // "unlockId" -> tästä kuva
        //        foreach (var token in unlocksToken)
        //        {
        //            System.Diagnostics.Debug.WriteLine("-> " + token.ToString().Length);
        //            foreach (var t in token)
        //            {
        //                System.Diagnostics.Debug.WriteLine("-> " + t.ToString().Length);
        //            }
        //        }
        //        System.Diagnostics.Debug.WriteLine("- - - - - ");
        //        continue;
        //        string guid = unlocksToken.SelectToken("weaponAddonUnlock").SelectToken("unlockId").ToString();
        //        System.Diagnostics.Debug.WriteLine("-> " + guid);
        //        // "weaponCode" -> tästä mihin liittyy
        //        IUnlock unlock = new Unlock()
        //        {
        //            Slug = unlocksToken.SelectToken("weaponAddonUnlock").SelectToken("slug").ToString(),
        //            Completion = Convert.ToInt32(unlocksToken.SelectToken("weaponAddonUnlock").SelectToken("unlockedBy").SelectToken("completion").ToString()),
        //        };

        //        string image = jObject.SelectToken("data").SelectToken("bf3GadgetsLocale").SelectToken("weaponaccessory").
        //            SelectToken(guid).SelectToken("image").ToString() + ImageSuffix;
        //        _imageRepository.Load(
        //            Common.WeaponAndAccessoryImageUrl, image, bitmap => { unlock.Image = bitmap; });
        //        unlocks.Add(unlock);
        //    }

        //    //var sortedAndFiltered = unlocks.OrderByDescending(g => g.Kills).ThenBy(g => g.Slug).ThenBy(g => g.Name).Where(g => g.Kills > 0);
        //    //return new Unlocks(sortedAndFiltered.ToList());
        //    return new Unlocks(unlocks);
        //}
    }
}
