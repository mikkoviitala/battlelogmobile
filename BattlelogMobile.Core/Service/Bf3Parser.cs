using System;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using BattlelogMobile.Core.Model;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattlelogMobile.Core.Service
{
    public class Bf3Parser : JSONParser<Battlefield3Data>
    {
        private Battlefield3Data _data = new Battlefield3Data();

        public override Battlefield3Data Parse()
        {
            IsolatedStorageFileStream resource = null;
            
            try
            {
                resource = IsolatedStorage.OpenFile(Common.Bf3OverviewFile, FileMode.Open);
                var streamReader = new StreamReader(resource);
            
                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");

                _data = JsonConvert.DeserializeObject<Battlefield3Data>(dataToken.ToString());

                ParseVehicles(Common.Bf3VehiclesFile);
                ParseWeapons(Common.Bf3WeaponsAndGadgetsFile);
                ParseGadgets(Common.Bf3WeaponsAndGadgetsFile);

                _data.Overview.KitServiceStars.Sort((p1, p2) =>
                                                    string.CompareOrdinal(
                                                        ((int)p1.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1),
                                                        ((int)p2.Type).ToString(CultureInfo.InvariantCulture).Substring(0, 1)));

                return _data;
            }
            catch (Exception e)
            {
                if (e is JsonReaderException || e is IOException || e is ArgumentException || e is FormatException || e is NullReferenceException)
                    Messenger.Default.Send(new NotificationMessage(this, Common.JsonParseFailedMessage));
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
            using (var streamReader = new StreamReader(IsolatedStorage.OpenFile(file, FileMode.Open)))
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
            
            _data.Vehicles = data.Vehicles;
        }

        private void ParseWeapons(string file)
        {
            string completeJson;
            using (var reader = new StreamReader(IsolatedStorage.OpenFile(file, FileMode.Open)))
                completeJson = reader.ReadToEnd();
            JObject jObject = JObject.Parse(completeJson);

            var data = JsonConvert.DeserializeObject<WeaponsData>(jObject.SelectToken("data").ToString());
            data.Weapons = data.Weapons.OrderByDescending(g => g.Kills).
                                ThenByDescending(g => g.Headshots).ThenBy(g => g.Slug).ThenBy(g => g.Name).Where(g => g.Kills > 0).ToList();
            data.Weapons = data.Weapons.Distinct(new ItemComparer()).ToList();

            foreach (var weapon in data.Weapons)
            {
                string imageName = jObject.SelectToken("data").SelectToken("gadgetsLocale").SelectToken("weapons").SelectToken(weapon.Guid).SelectToken("image") + Common.ImageSuffix;
                weapon.ImageName = imageName;
            }

            _data.Weapons = data.Weapons;
        }

        private void ParseGadgets(string file)
        {
            string completeJson;
            using (var reader = new StreamReader(IsolatedStorage.OpenFile(file, FileMode.Open)))
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

            _data.Gadgets = data.Gadgets;
        }
    }
}