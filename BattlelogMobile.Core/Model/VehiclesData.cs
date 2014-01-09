using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class VehiclesData
    {
        [JsonProperty(PropertyName = "mainVehicleStats")]
        public List<ItemContainer> Vehicles { get; set; }
    }
}