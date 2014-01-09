using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class GadgetsData
    {
        [JsonProperty(PropertyName = "mainItemStats")]
        public List<GadgetContainer> Gadgets { get; set; }
    }
}