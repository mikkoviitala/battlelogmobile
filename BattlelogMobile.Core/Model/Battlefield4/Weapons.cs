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

            public double serviceStars { get; set; }
            public double serviceStarsProgress { get; set; }
            public double? shotsFired { get; set; }
            public double? accuracy { get; set; }
            public double? headshots { get; set; }
            public double kills { get; set; }

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

            public double? shotsHit { get; set; }
        }
    }
}
