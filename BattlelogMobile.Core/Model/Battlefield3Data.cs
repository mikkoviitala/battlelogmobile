using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class Battlefield3Data : BaseModel, IUpdateInfo
    {
        [JsonIgnore]
        public DateTime Updated { get; set; }

        private Overview _overview;
        [JsonProperty(PropertyName = "overviewStats")]
        public Overview Overview
        {
            get { return _overview; }
            set
            {
                _overview = value;
                RaisePropertyChanged("Overview");
            }
        }

        [JsonProperty(PropertyName = "user")]
        public BattlefieldUser User { get; set; }
        
        [JsonProperty(PropertyName = "awards")]
        public List<AwardContainer> Awards { get; set; }

        [JsonIgnore]
        public List<ItemContainer> Vehicles { get; set; }

        [JsonIgnore]
        public List<ItemContainer> Weapons { get; set; }

        [JsonIgnore]
        public List<GadgetContainer> Gadgets { get; set; }
    }
}
