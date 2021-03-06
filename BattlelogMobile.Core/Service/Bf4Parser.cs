﻿using System;
using System.IO;
using BattlelogMobile.Core.Model.Battlefield4;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattlelogMobile.Core.Service
{
    public class Bf4Parser : JSONParser<Battlefield4Data>
    {
        private readonly Battlefield4Data _data = new Battlefield4Data();

        public override Battlefield4Data Parse()
        {
            using (var resource = IsolatedStorage.OpenFile(Common.Bf4IndexFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");
                var indexData = JsonConvert.DeserializeObject<Index.Data>(dataToken.ToString());
                _data.Index = indexData;
            }

            //TODO: Do not download overview file
            //using (var resource = IsolatedStorage.OpenFile(Common.Bf4OverviewFile, FileMode.Open))
            //{
            //    var streamReader = new StreamReader(resource);

            //    string completeJson = streamReader.ReadToEnd();
            //    JObject jObject = JObject.Parse(completeJson);
            //    var dataToken = jObject.SelectToken("data");
            //    var overviewData = JsonConvert.DeserializeObject<Overview.Data>(dataToken.ToString());
            //    _data.Overview = overviewData;
            //}

            using (var resource = IsolatedStorage.OpenFile(Common.Bf4WeaponsAndGadgetsFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                string dataToken = jObject.SelectToken("data").ToString();
                var weaponsData = JsonConvert.DeserializeObject<Weapons.Data>(dataToken);
                _data.Weapons = weaponsData;
            }

            using (var resource = IsolatedStorage.OpenFile(Common.Bf4VehiclesFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                string dataToken = jObject.SelectToken("data").ToString();
                var vehiclesData = JsonConvert.DeserializeObject<Vehicles.Data>(dataToken);
                _data.Vehicles = vehiclesData;
            }

            _data.Updated = DateTime.Now;

            return _data;
        }
    }
}