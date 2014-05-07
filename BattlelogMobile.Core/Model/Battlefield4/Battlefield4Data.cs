using System;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Battlefield4Data : BaseModel, IUpdateInfo
    {
        [JsonIgnore]
        public DateTime Updated { get; set; }

        public Index.Data Index { get; set; }

        public Weapons.Data Weapons { get; set; }

        public Vehicles.Data Vehicles { get; set; }

        //public Overview.Data Overview { get; set; }
    }
}
