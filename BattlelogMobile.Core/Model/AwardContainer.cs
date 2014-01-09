using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class AwardContainer
    {
        [JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "award")]
        public Award Award { get; set; }
    }
}