using System;
using System.Collections.Generic;
using System.Linq;
using BattlelogMobile.Core.Service;
using Newtonsoft.Json;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Vehicles
    {
        public class Data : BaseModel
        {
            private List<Vehicle> _vehicles;
            [JsonProperty(PropertyName = "mainVehicleStats")]
            public List<Vehicle> mainVehicleStats
            {
                get { return _vehicles; }
                set
                {
                    _vehicles = value.OrderBy(v => v.slug).ToList();
                    //_vehicles = value.Where(v => v.kills > 0).
                    //            OrderByDescending(v => v.serviceStars).
                    //            ThenByDescending(v => v.kills).
                    //            ThenBy(v => v.slug)
                    //            .ToList();
                    RaisePropertyChanged("mainVehicleStats");
                }
            }
        }

        public class Vehicle : BaseModel
        {
            [JsonIgnore]
            public string Image
            {
                get { return string.Format("{0}.png", slug); }
            }

            [JsonIgnore]
            public string DisplayName
            {
                get { return ItemNameMapper.Get(slug.ToUpper()); }
            }

            public double serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public string code { get; set; }
            public double kills { get; set; }
            public string guid { get; set; }

            private TimeSpan? _timeIn;
            [JsonIgnore]
            public TimeSpan? TimeIn
            {
                get { return _timeIn; }
                set
                {
                    _timeIn = value;
                    RaisePropertyChanged("timeIn");
                }
            }

            private string _timeInSeconds;
            [JsonProperty(PropertyName = "timeIn")]
            [ExcludeFromSerialization]
            public string TimeInSeconds
            {
                get { return _timeInSeconds; }
                set
                {
                    _timeInSeconds = value;
                    TimeIn = TimeSpan.FromSeconds(Convert.ToInt32(_timeInSeconds));
                }
            }

            private string _slug;
            public string slug
            {
                get { return _slug; }
                set
                {
                    _slug = value;
                    RaisePropertyChanged("slug");
                    RaisePropertyChanged("DisplayName");
                    RaisePropertyChanged("Image");
                }
            }

            public string category { get; set; }
            public string name { get; set; }
            public object killsDelta { get; set; }
            public object vehicle { get; set; }
            public object type { get; set; }
            public object timeInDelta { get; set; }
        }

        //public class UnlockProgression
        //{
        //    public List<Template> __invalid_name__Vehicle Air Helicopter Scout { get; set; }
        //    public List<Template> __invalid_name__Vehicle Fast Attack Craft { get; set; }
        //    public List<Template> __invalid_name__Vehicle Infantry Fighting Vehicle { get; set; }
        //    public List<Template> __invalid_name__Vehicle Air Jet Attack { get; set; }
        //    public List<Template> __invalid_name__Vehicle Air Helicopter Attack { get; set; }
        //    public List<Template> __invalid_name__Vehicle Main Battle Tanks { get; set; }
        //    public List<Template> __invalid_name__Vehicle Air Jet Stealth { get; set; }
        //    public List<Template> __invalid_name__Vehicle Anti Air { get; set; }
        //}

        //public class VehicleTaken
        //{
        //    public int taken { get; set; }
        //    public int total { get; set; }
        //}

        //public class UnlockProgressionAmount
        //{
        //    [JsonProperty(PropertyName = "Vehicle Air Helicopter Scout")]
        //    public VehicleTaken ScoutHeli { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Fast Attack Craft")]
        //    public VehicleTaken FAC { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Infantry Fighting Vehicle")]
        //    public VehicleTaken IFV { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Air Jet Attack")]
        //    public VehicleTaken AttackJet { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Air Helicopter Attack")]
        //    public VehicleTaken AttackHeli { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Main Battle Tanks")]
        //    public VehicleTaken MBT { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Air Jet Stealth")]
        //    public VehicleTaken StealthJet { get; set; }

        //    [JsonProperty(PropertyName = "Vehicle Anti Air")]
        //    public VehicleTaken AA { get; set; }
        //}
    }
}
