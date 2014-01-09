using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model
{
    public class Performance : BaseModel
    {
        private int _stat;
        [JsonProperty(PropertyName = "stat")]
        public int Stat
        {
            get { return _stat; }
            set
            {
                _stat = value;
                RaisePropertyChanged("Stat");
            }
        }

        private string _name;
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}