using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Battlefield4Data : BaseModel, IUpdateInfo
    {
        [JsonIgnore]
        public DateTime Updated { get; set; }

        public Index.Data Index { get; set; }

        //public Overview.Data Overview { get; set; }

        public Weapons.Data Weapons { get; set; }
    }
}
