using System.Collections.Generic;
using System.Linq;
using BattlelogMobile.Core.Service;
using Newtonsoft.Json;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Weapons
    {
        public class Data : BaseModel
        {
            private List<Weapon> _weapons;
            [JsonProperty(PropertyName = "mainWeaponStats")]
            public List<Weapon> mainWeaponStats
            {
                get { return _weapons; }
                set
                {
                    _weapons = value.Where(w => w.kills > 0).
                                OrderByDescending(w => w.serviceStars).
                                ThenByDescending(w => w.kills).
                                ThenByDescending(w => w.headshots).
                                ThenBy(w => w.slug)
                                .ToList();
                    RaisePropertyChanged("mainWeaponStats");
                }
            }
        }

        public class Weapon : BaseModel
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

            private double _serviceStars ;
            public double serviceStars
            {
                get { return _serviceStars; } 
                set
                {
                    _serviceStars = value;
                    RaisePropertyChanged("serviceStars");
                }
            }

            private double? _shotsFired;
            public double? shotsFired
            {
                get { return _shotsFired; }
                set
                {
                    _shotsFired = value;
                    RaisePropertyChanged("shotsFired");
                }
            }

            private double? _accuracy;
            public double? accuracy
            {
                get { return _accuracy; }
                set
                {
                    _accuracy = value;
                    RaisePropertyChanged("accuracy");
                }
            }

            private double? _headshots;
            public double? headshots
            {
                get { return _headshots; }
                set
                {
                    _headshots = value;
                    RaisePropertyChanged("headshots");
                }
            }

            private double _kills;
            public double kills
            {
                get { return _kills; }
                set
                {
                    _kills = value;
                    RaisePropertyChanged("kills");
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

            //public double serviceStarsProgress { get; set; }
            //public double? shotsHit { get; set; }
        }
    }
}
