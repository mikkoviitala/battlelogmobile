using System.Windows.Media.Imaging;
using BattlelogMobile.Core.Service;
using Polenter.Serialization;

namespace BattlelogMobile.Core.Model
{
    // data - awards
    public class Award : BaseModel, IAward
    {
        private BitmapImage _bitmap;
        //private const string RibbonsGroup = "AwardGroup_Ribbons";
        private const string MedalsGroup = "AwardGroup_Medals";
        
        // 1.2 * original size...
        private const int RibbonWidth = (int)(1.2 * 78);
        private const int RibbonHeight = (int)(1.2 * 28);

        private const int MedalWidth = (int)(1.2 * 52);
        private const int MedalHeight = (int)(1.2 * 52);

        public string Code { get; set; }         // code
        public string Group { get; set; }        // awardGroup

        [ExcludeFromSerialization]
        public BitmapImage Image
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged("Image"); }
        }

        public string ImageName { get { return AwardPropertyMapper.Get(Code, Group).Item3; } }
        public string ImageSaveName
        {
            get
            {
                if (Group.Equals(MedalsGroup))
                    return string.Format("{0}{1}", Common.MedalAwardSavePrefix, ImageName);
                return string.Format("{0}{1}", Common.RibbonAwardSavePrefix, ImageName);
            }
        }

        public int Width { get { return Group.Equals(MedalsGroup) ? MedalWidth : RibbonWidth; } }
        public int Height { get { return Group.Equals(MedalsGroup) ? MedalHeight : RibbonHeight; } }

        public string Name { get { return AwardPropertyMapper.Get(Code, Group).Item1; } }
        public string Description { get { return AwardPropertyMapper.Get(Code, Group).Item2; } }

        public override string ToString()
        {
            return string.Format("Code={0}, Group={1}", Code, Group);
        }
    }
}