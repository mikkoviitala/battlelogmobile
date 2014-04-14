using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
                    _weapons = value.OrderBy(w => w.slug).ToList();
                    //_weapons = value.Where(w => w.kills > 0).
                    //            OrderByDescending(g => g.kills).
                    //            ThenByDescending(g => g.headshots).
                    //            ThenBy(g => g.slug).
                    //            ThenBy(g => g.name)
                    //            .ToList();
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
            //public string code { get; set; }
            //public object deaths { get; set; }
            //public string categorySID { get; set; }
            //public object unlockImageConfig { get; set; }
            //public string guid { get; set; }
            //public string category { get; set; }
            public double? shotsFired { get; set; }
            //public object unlocked { get; set; }
            //public object timeEquippedDelta { get; set; }
            //public object score { get; set; }
            //public object type { get; set; }
            //public object imageConfig { get; set; }
            public double? accuracy { get; set; }
            //public object startedWith { get; set; }
            public double? headshots { get; set; }
            public double kills { get; set; }
            //public List<object> unlocks { get; set; }
            //public List<object> kit { get; set; }
            //public object duplicateOf { get; set; }

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
            //public double? timeEquipped { get; set; }
            //public object killsPerMinuteDelta { get; set; }
            //public string name { get; set; }
            //public object weapon { get; set; }
            public double? shotsHit { get; set; }
            //public object killsDelta { get; set; }
        }
    }
}
