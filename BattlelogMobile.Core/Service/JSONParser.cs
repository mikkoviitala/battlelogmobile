using System;
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
    public class JSONParser
    {
        private readonly IsolatedStorageFile _isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        private readonly ImageRepository _imageRepository = new ImageRepository();
        private BattlefieldData _battlefieldData = new BattlefieldData();

        /// <summary>
        /// Here lies some nasty JSON parsing...
        /// </summary>
        /// <returns></returns>
        public BattlefieldData Parse()
        {
            IsolatedStorageFileStream resource = null;
            
            try
            {
                resource = _isolatedStorage.OpenFile(Common.OverviewFile, FileMode.Open);
                var streamReader = new StreamReader(resource);
            
                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");

                _battlefieldData = JsonConvert.DeserializeObject<BattlefieldData>(dataToken.ToString());

                ParseVehicles(Common.VehiclesFile);
                ParseWeapons(Common.WeaponsAndGadgetsFile);
                ParseGadgets(Common.WeaponsAndGadgetsFile);

               _battlefieldData.Overview.KitServiceStars.Sort((p1, p2) =>
               string.CompareOrdinal(
                   ((int)p1.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1),
                       ((int)p2.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1)));

                return _battlefieldData;
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

        private void ParseVehicles(string file)
        {
            string completeJson;
            using (var streamReader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
                completeJson = streamReader.ReadToEnd();
            JObject jObject = JObject.Parse(completeJson);

            var data = JsonConvert.DeserializeObject<VehiclesData>(jObject.SelectToken("data").ToString());
            data.Vehicles = data.Vehicles.OrderByDescending(v => v.Kills).ThenByDescending(v => v.TimeIn).
                ThenBy(v => v.Slug).ThenBy(v => v.Name).Where(g => g.Kills > 0).ToList();
            
            foreach (var vehicle in data.Vehicles)
            {
                string imageName = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("vehicles").SelectToken(vehicle.Guid).SelectToken("image") + Common.ImageSuffix;
                vehicle.ImageName = imageName;
            }
            
            _battlefieldData.Vehicles = data.Vehicles;
        }

        private void ParseWeapons(string file)
        {
            string completeJson;
            using (var reader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
                completeJson = reader.ReadToEnd();
            JObject jObject = JObject.Parse(completeJson);

            var data = JsonConvert.DeserializeObject<WeaponsData>(jObject.SelectToken("data").ToString());
            data.Weapons = data.Weapons.OrderByDescending(g => g.Kills).
                ThenByDescending(g => g.Headshots).ThenBy(g => g.Slug).ThenBy(g => g.Name).
                    Where(g => g.Kills > 0).ToList();
            data.Weapons = data.Weapons.Distinct(new ItemComparer()).ToList();

            foreach (var weapon in data.Weapons)
            {
                int kills = Convert.ToInt32(weapon.Kills);
                if (kills == 0)
                    continue;

                string imageName = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("weapons").SelectToken(weapon.Guid).SelectToken("image") + Common.ImageSuffix;
                weapon.ImageName = imageName;

                _imageRepository.Load(Common.ServiceStarImageUrl, Common.ServiceStarImage, bitmap => { weapon.ServiceStarImage = bitmap; });
                _imageRepository.Load(Common.WeaponAndAccessoryImageUrl, weapon.ImageName, bitmap => { weapon.Image = bitmap; });
            }

            _battlefieldData.Weapons = data.Weapons;
        }

        private void ParseGadgets(string file)
        {
            string completeJson;
            using (var reader = new StreamReader(_isolatedStorage.OpenFile(file, FileMode.Open)))
                completeJson = reader.ReadToEnd();
            JObject jObject = JObject.Parse(completeJson);

            var data = JsonConvert.DeserializeObject<GadgetsData>(jObject.SelectToken("data").ToString());
            data.Gadgets = data.Gadgets.Where(g => g.Performances != null && g.Performances.Any()).
                OrderByDescending(g => (g.Performances[0].Stat)).ThenBy(g => g.Slug).ThenBy(g => g.Name).ToList();

            foreach (var gadget in data.Gadgets)
            {
                string imageName = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("kititems").SelectToken(gadget.Guid).SelectToken("image") + Common.ImageSuffix;
                gadget.ImageName = imageName;
            }

            _battlefieldData.Gadgets = data.Gadgets;
        }
    }
}
