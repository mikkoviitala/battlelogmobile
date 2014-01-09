using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class WeaponsData
    {
        [JsonProperty(PropertyName = "mainWeaponStats")]
        public List<ItemContainer> Weapons { get; set; }
    }
}