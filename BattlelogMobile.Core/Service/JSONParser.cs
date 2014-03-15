using System.IO;
using System.IO.IsolatedStorage;
using BattlelogMobile.Core.Model.Battlefield4;
using BattlelogMobile.Core.Model.Battlefield4.Vehiclez;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Overview = BattlelogMobile.Core.Model.Battlefield4.Overview;

namespace BattlelogMobile.Core.Service
{
    public abstract class JSONParser<T>
    {
        protected readonly IsolatedStorageFile IsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        public abstract T Parse();
    }

    public class Bf4Parser : JSONParser<BattlelogMobile.Core.Model.Battlefield4.Overview>
    {
        private Overview _data = new Overview();

        public override Overview Parse()
        {
            //using (var resource = IsolatedStorage.OpenFile(Common.Bf4OverviewFile, FileMode.Open))
            //{
            //    var streamReader = new StreamReader(resource);

            //    string completeJson = streamReader.ReadToEnd();
            //    JObject jObject = JObject.Parse(completeJson);
            //    var dataToken = jObject.SelectToken("data");
            //    var a = JsonConvert.DeserializeObject<Battlefield4Data>(dataToken.ToString());
            //}

            using (var resource = IsolatedStorage.OpenFile(Common.Bf4OverviewFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");
                var a = JsonConvert.DeserializeObject<Overview.Data>(dataToken.ToString());
            }

            using (var resource = IsolatedStorage.OpenFile(Common.Bf4VehiclesFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");
                var a = JsonConvert.DeserializeObject<BattlelogMobile.Core.Model.Battlefield4.Vehiclez.RootObject>(completeJson);
                var b = JsonConvert.DeserializeObject<BattlelogMobile.Core.Model.Battlefield4.Vehiclez.Data>(dataToken.ToString());
            }

            using (var resource = IsolatedStorage.OpenFile(Common.Bf4WeaponsAndGadgetsFile, FileMode.Open))
            {
                var streamReader = new StreamReader(resource);

                string completeJson = streamReader.ReadToEnd();
                JObject jObject = JObject.Parse(completeJson);
                var dataToken = jObject.SelectToken("data");
                var a = JsonConvert.DeserializeObject<BattlelogMobile.Core.Model.Battlefield4.Weapons.Data>(dataToken.ToString());
            }
            return _data;
            
        }
    }
}
