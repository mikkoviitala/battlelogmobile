using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattlelogMobile.Core.Model.Battlefield4
{
    public class Weapons
    {
        public class ParamYcategories
        {
        }

        public class ParamXcategories
        {
            public string AwardCategories { get; set; }
        }

        public class Criteria
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories paramYcategories { get; set; }
            public ParamXcategories paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats
        {
            public Completioncount completioncount { get; set; }
            public Timestamp timestamp { get; set; }
        }

        public class Mobile
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions
        {
            public Mobile mobile { get; set; }
            public Large large { get; set; }
            public Mediumns mediumns { get; set; }
            public Xsmall xsmall { get; set; }
            public Small small { get; set; }
            public Smallns smallns { get; set; }
        }

        public class ImageConfig
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions versions { get; set; }
        }

        public class Unlock
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award2
        {
            public string code { get; set; }
            public List<Criteria> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig imageConfig { get; set; }
            public List<Unlock> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        //public class __invalid_type__2608155982C84E5F961D0066D858ADA2
        //{
        //    public string codeNeeded { get; set; }
        //    public object valueNeededPlain { get; set; }
        //    public object completed { get; set; }
        //    public Award2 award { get; set; }
        //    public object bucketRelativeCompletion { get; set; }
        //    public object numSecondsLeft { get; set; }
        //    public object numRoundsLeft { get; set; }
        //    public int completion { get; set; }
        //    public object license { get; set; }
        //    public string unlockType { get; set; }
        //    public string bucket { get; set; }
        //    public int actualValue { get; set; }
        //    public int valueNeeded { get; set; }
        //}

        public class ParamYcategories2
        {
        }

        public class ParamXcategories2
        {
        }

        public class Criteria2
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public object unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public object paramX { get; set; }
            public ParamYcategories2 paramYcategories { get; set; }
            public ParamXcategories2 paramXcategories { get; set; }
            public object paramY { get; set; }
            public object statCode { get; set; }
        }

        public class Completioncount2
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp2
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats2
        {
            public Completioncount2 completioncount { get; set; }
            public Timestamp2 timestamp { get; set; }
        }

        public class Mobile2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns2
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions2
        {
            public Mobile2 mobile { get; set; }
            public Large2 large { get; set; }
            public Mediumns2 mediumns { get; set; }
            public Xsmall2 xsmall { get; set; }
            public Small2 small { get; set; }
            public Smallns2 smallns { get; set; }
        }

        public class ImageConfig2
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions2 versions { get; set; }
        }

        public class Unlock2
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency2
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award3
        {
            public string code { get; set; }
            public List<Criteria2> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats2 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig2 imageConfig { get; set; }
            public List<Unlock2> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency2> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

       public class ParamYcategories3
        {
        }

        public class ParamXcategories3
        {
        }

        public class Criteria3
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public object unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public object paramX { get; set; }
            public ParamYcategories3 paramYcategories { get; set; }
            public ParamXcategories3 paramXcategories { get; set; }
            public object paramY { get; set; }
            public object statCode { get; set; }
        }

        public class Completioncount3
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp3
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats3
        {
            public Completioncount3 completioncount { get; set; }
            public Timestamp3 timestamp { get; set; }
        }

        public class Mobile3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns3
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions3
        {
            public Mobile3 mobile { get; set; }
            public Large3 large { get; set; }
            public Mediumns3 mediumns { get; set; }
            public Xsmall3 xsmall { get; set; }
            public Small3 small { get; set; }
            public Smallns3 smallns { get; set; }
        }

        public class ImageConfig3
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions3 versions { get; set; }
        }

        public class Unlock3
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency3
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award4
        {
            public string code { get; set; }
            public List<Criteria3> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats3 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig3 imageConfig { get; set; }
            public List<Unlock3> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency3> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class Completioncount4
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp4
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats4
        {
            public Completioncount4 completioncount { get; set; }
            public Timestamp4 timestamp { get; set; }
        }

        public class Mobile4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns4
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions4
        {
            public Mobile4 mobile { get; set; }
            public Large4 large { get; set; }
            public Mediumns4 mediumns { get; set; }
            public Xsmall4 xsmall { get; set; }
            public Small4 small { get; set; }
            public Smallns4 smallns { get; set; }
        }

        public class ImageConfig4
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions4 versions { get; set; }
        }

        public class Unlock4
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award5
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats4 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig4 imageConfig { get; set; }
            public List<Unlock4> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }


        public class ParamYcategories4
        {
        }

        public class ParamXcategories4
        {
            public string AwardCategories { get; set; }
        }

        public class Criteria4
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories4 paramYcategories { get; set; }
            public ParamXcategories4 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount5
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp5
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats5
        {
            public Completioncount5 completioncount { get; set; }
            public Timestamp5 timestamp { get; set; }
        }

        public class Mobile5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns5
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions5
        {
            public Mobile5 mobile { get; set; }
            public Large5 large { get; set; }
            public Mediumns5 mediumns { get; set; }
            public Xsmall5 xsmall { get; set; }
            public Small5 small { get; set; }
            public Smallns5 smallns { get; set; }
        }

        public class ImageConfig5
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions5 versions { get; set; }
        }

        public class Unlock5
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency4
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award6
        {
            public string code { get; set; }
            public List<Criteria4> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats5 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig5 imageConfig { get; set; }
            public List<Unlock5> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency4> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories5
        {
        }

        public class ParamXcategories5
        {
            public string VehicleCategories { get; set; }
            public string AwardCategories { get; set; }
        }

        public class Criteria5
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories5 paramYcategories { get; set; }
            public ParamXcategories5 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount6
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp6
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats6
        {
            public Completioncount6 completioncount { get; set; }
            public Timestamp6 timestamp { get; set; }
        }

        public class Mobile6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns6
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions6
        {
            public Mobile6 mobile { get; set; }
            public Large6 large { get; set; }
            public Mediumns6 mediumns { get; set; }
            public Xsmall6 xsmall { get; set; }
            public Small6 small { get; set; }
            public Smallns6 smallns { get; set; }
        }

        public class ImageConfig6
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions6 versions { get; set; }
        }

        public class Unlock6
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency5
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award7
        {
            public string code { get; set; }
            public List<Criteria5> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats6 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig6 imageConfig { get; set; }
            public List<Unlock6> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency5> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class Completioncount7
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp7
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats7
        {
            public Completioncount7 completioncount { get; set; }
            public Timestamp7 timestamp { get; set; }
        }

        public class Mobile7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns7
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions7
        {
            public Mobile7 mobile { get; set; }
            public Large7 large { get; set; }
            public Mediumns7 mediumns { get; set; }
            public Xsmall7 xsmall { get; set; }
            public Small7 small { get; set; }
            public Smallns7 smallns { get; set; }
        }

        public class ImageConfig7
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions7 versions { get; set; }
        }

        public class Unlock7
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award8
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats7 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig7 imageConfig { get; set; }
            public List<Unlock7> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class AEAA518B925340C2AA18A11F8F2D474C
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award8 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class Completioncount8
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp8
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats8
        {
            public Completioncount8 completioncount { get; set; }
            public Timestamp8 timestamp { get; set; }
        }

        public class Mobile8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns8
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions8
        {
            public Mobile8 mobile { get; set; }
            public Large8 large { get; set; }
            public Mediumns8 mediumns { get; set; }
            public Xsmall8 xsmall { get; set; }
            public Small8 small { get; set; }
            public Smallns8 smallns { get; set; }
        }

        public class ImageConfig8
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions8 versions { get; set; }
        }

        public class Unlock8
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award9
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats8 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig8 imageConfig { get; set; }
            public List<Unlock8> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class A1A5DE0C19A79C842DEB196832622C2A
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award9 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public object bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories6
        {
        }

        public class ParamXcategories6
        {
            public string VehicleCategories { get; set; }
        }

        public class Criteria6
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories6 paramYcategories { get; set; }
            public ParamXcategories6 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount9
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp9
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats9
        {
            public Completioncount9 completioncount { get; set; }
            public Timestamp9 timestamp { get; set; }
        }

        public class Mobile9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns9
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions9
        {
            public Mobile9 mobile { get; set; }
            public Large9 large { get; set; }
            public Mediumns9 mediumns { get; set; }
            public Xsmall9 xsmall { get; set; }
            public Small9 small { get; set; }
            public Smallns9 smallns { get; set; }
        }

        public class ImageConfig9
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions9 versions { get; set; }
        }

        public class Unlock9
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency6
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award10
        {
            public string code { get; set; }
            public List<Criteria6> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats9 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig9 imageConfig { get; set; }
            public List<Unlock9> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency6> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class BD68C1FD9B3A4F9EB29D067F53BC92B0
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public bool completed { get; set; }
            public Award10 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories7
        {
        }

        public class ParamXcategories7
        {
            public string AwardCategories { get; set; }
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria7
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories7 paramYcategories { get; set; }
            public ParamXcategories7 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount10
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp10
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats10
        {
            public Completioncount10 completioncount { get; set; }
            public Timestamp10 timestamp { get; set; }
        }

        public class Mobile10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns10
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions10
        {
            public Mobile10 mobile { get; set; }
            public Large10 large { get; set; }
            public Mediumns10 mediumns { get; set; }
            public Xsmall10 xsmall { get; set; }
            public Small10 small { get; set; }
            public Smallns10 smallns { get; set; }
        }

        public class ImageConfig10
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions10 versions { get; set; }
        }

        public class Unlock10
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency7
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award11
        {
            public string code { get; set; }
            public List<Criteria7> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats10 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig10 imageConfig { get; set; }
            public List<Unlock10> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency7> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class EC1CE991C625461A92014F460767D3D4
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award11 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class Completioncount11
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp11
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats11
        {
            public Completioncount11 completioncount { get; set; }
            public Timestamp11 timestamp { get; set; }
        }

        public class Mobile11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns11
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions11
        {
            public Mobile11 mobile { get; set; }
            public Large11 large { get; set; }
            public Mediumns11 mediumns { get; set; }
            public Xsmall11 xsmall { get; set; }
            public Small11 small { get; set; }
            public Smallns11 smallns { get; set; }
        }

        public class ImageConfig11
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions11 versions { get; set; }
        }

        public class Unlock11
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award12
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats11 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig11 imageConfig { get; set; }
            public List<Unlock11> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class C12E6868FC084E258AD01C51201EA69B
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award12 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class Completioncount12
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp12
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats12
        {
            public Completioncount12 completioncount { get; set; }
            public Timestamp12 timestamp { get; set; }
        }

        public class Mobile12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns12
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions12
        {
            public Mobile12 mobile { get; set; }
            public Large12 large { get; set; }
            public Mediumns12 mediumns { get; set; }
            public Xsmall12 xsmall { get; set; }
            public Small12 small { get; set; }
            public Smallns12 smallns { get; set; }
        }

        public class ImageConfig12
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions12 versions { get; set; }
        }

        public class Unlock12
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award13
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats12 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig12 imageConfig { get; set; }
            public List<Unlock12> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        
        public class ParamYcategories8
        {
        }

        public class ParamXcategories8
        {
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria8
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories8 paramYcategories { get; set; }
            public ParamXcategories8 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount13
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp13
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats13
        {
            public Completioncount13 completioncount { get; set; }
            public Timestamp13 timestamp { get; set; }
        }

        public class Mobile13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns13
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions13
        {
            public Mobile13 mobile { get; set; }
            public Large13 large { get; set; }
            public Mediumns13 mediumns { get; set; }
            public Xsmall13 xsmall { get; set; }
            public Small13 small { get; set; }
            public Smallns13 smallns { get; set; }
        }

        public class ImageConfig13
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions13 versions { get; set; }
        }

        public class Unlock13
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency8
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award14
        {
            public string code { get; set; }
            public List<Criteria8> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats13 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig13 imageConfig { get; set; }
            public List<Unlock13> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency8> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }


        public class ParamYcategories9
        {
        }

        public class ParamXcategories9
        {
            public string WeaponStatCategories { get; set; }
            public string AwardCategories { get; set; }
        }

        public class Criteria9
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories9 paramYcategories { get; set; }
            public ParamXcategories9 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount14
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp14
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats14
        {
            public Completioncount14 completioncount { get; set; }
            public Timestamp14 timestamp { get; set; }
        }

        public class Mobile14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns14
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions14
        {
            public Mobile14 mobile { get; set; }
            public Large14 large { get; set; }
            public Mediumns14 mediumns { get; set; }
            public Xsmall14 xsmall { get; set; }
            public Small14 small { get; set; }
            public Smallns14 smallns { get; set; }
        }

        public class ImageConfig14
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions14 versions { get; set; }
        }

        public class Unlock14
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency9
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award15
        {
            public string code { get; set; }
            public List<Criteria9> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats14 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig14 imageConfig { get; set; }
            public List<Unlock14> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency9> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories10
        {
        }

        public class ParamXcategories10
        {
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria10
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories10 paramYcategories { get; set; }
            public ParamXcategories10 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount15
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp15
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats15
        {
            public Completioncount15 completioncount { get; set; }
            public Timestamp15 timestamp { get; set; }
        }

        public class Mobile15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns15
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions15
        {
            public Mobile15 mobile { get; set; }
            public Large15 large { get; set; }
            public Mediumns15 mediumns { get; set; }
            public Xsmall15 xsmall { get; set; }
            public Small15 small { get; set; }
            public Smallns15 smallns { get; set; }
        }

        public class ImageConfig15
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions15 versions { get; set; }
        }

        public class Unlock15
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency10
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award16
        {
            public string code { get; set; }
            public List<Criteria10> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats15 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig15 imageConfig { get; set; }
            public List<Unlock15> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency10> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories11
        {
            public string WeaponStatCategories { get; set; }
        }

        public class ParamXcategories11
        {
            public string AwardCategories { get; set; }
            public string VehicleCategories { get; set; }
        }

        public class Criteria11
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories11 paramYcategories { get; set; }
            public ParamXcategories11 paramXcategories { get; set; }
            public string paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount16
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp16
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats16
        {
            public Completioncount16 completioncount { get; set; }
            public Timestamp16 timestamp { get; set; }
        }

        public class Mobile16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns16
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions16
        {
            public Mobile16 mobile { get; set; }
            public Large16 large { get; set; }
            public Mediumns16 mediumns { get; set; }
            public Xsmall16 xsmall { get; set; }
            public Small16 small { get; set; }
            public Smallns16 smallns { get; set; }
        }

        public class ImageConfig16
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions16 versions { get; set; }
        }

        public class Unlock16
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency11
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award17
        {
            public string code { get; set; }
            public List<Criteria11> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats16 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig16 imageConfig { get; set; }
            public List<Unlock16> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency11> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories12
        {
        }

        public class ParamXcategories12
        {
            public string AwardCategories { get; set; }
        }

        public class Criteria12
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories12 paramYcategories { get; set; }
            public ParamXcategories12 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount17
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp17
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats17
        {
            public Completioncount17 completioncount { get; set; }
            public Timestamp17 timestamp { get; set; }
        }

        public class Mobile17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns17
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions17
        {
            public Mobile17 mobile { get; set; }
            public Large17 large { get; set; }
            public Mediumns17 mediumns { get; set; }
            public Xsmall17 xsmall { get; set; }
            public Small17 small { get; set; }
            public Smallns17 smallns { get; set; }
        }

        public class ImageConfig17
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions17 versions { get; set; }
        }

        public class Unlock17
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency12
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award18
        {
            public string code { get; set; }
            public List<Criteria12> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats17 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig17 imageConfig { get; set; }
            public List<Unlock17> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency12> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories13
        {
        }

        public class ParamXcategories13
        {
            public string AwardCategories { get; set; }
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria13
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories13 paramYcategories { get; set; }
            public ParamXcategories13 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount18
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp18
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats18
        {
            public Completioncount18 completioncount { get; set; }
            public Timestamp18 timestamp { get; set; }
        }

        public class Mobile18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns18
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions18
        {
            public Mobile18 mobile { get; set; }
            public Large18 large { get; set; }
            public Mediumns18 mediumns { get; set; }
            public Xsmall18 xsmall { get; set; }
            public Small18 small { get; set; }
            public Smallns18 smallns { get; set; }
        }

        public class ImageConfig18
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions18 versions { get; set; }
        }

        public class Unlock18
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency13
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award19
        {
            public string code { get; set; }
            public List<Criteria13> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats18 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig18 imageConfig { get; set; }
            public List<Unlock18> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency13> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }
        
        public class Completioncount19
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp19
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats19
        {
            public Completioncount19 completioncount { get; set; }
            public Timestamp19 timestamp { get; set; }
        }

        public class Mobile19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns19
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions19
        {
            public Mobile19 mobile { get; set; }
            public Large19 large { get; set; }
            public Mediumns19 mediumns { get; set; }
            public Xsmall19 xsmall { get; set; }
            public Small19 small { get; set; }
            public Smallns19 smallns { get; set; }
        }

        public class ImageConfig19
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions19 versions { get; set; }
        }

        public class Unlock19
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Award20
        {
            public string code { get; set; }
            public List<object> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats19 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig19 imageConfig { get; set; }
            public List<Unlock19> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<object> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories14
        {
            public string LevelCategories { get; set; }
        }

        public class ParamXcategories14
        {
            public string AwardCategories { get; set; }
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria14
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories14 paramYcategories { get; set; }
            public ParamXcategories14 paramXcategories { get; set; }
            public string paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount20
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp20
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats20
        {
            public Completioncount20 completioncount { get; set; }
            public Timestamp20 timestamp { get; set; }
        }

        public class Mobile20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns20
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions20
        {
            public Mobile20 mobile { get; set; }
            public Large20 large { get; set; }
            public Mediumns20 mediumns { get; set; }
            public Xsmall20 xsmall { get; set; }
            public Small20 small { get; set; }
            public Smallns20 smallns { get; set; }
        }

        public class ImageConfig20
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions20 versions { get; set; }
        }

        public class Unlock20
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency14
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award21
        {
            public string code { get; set; }
            public List<Criteria14> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats20 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig20 imageConfig { get; set; }
            public List<Unlock20> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency14> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories15
        {
        }

        public class ParamXcategories15
        {
            public string VehicleCategories { get; set; }
        }

        public class Criteria15
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories15 paramYcategories { get; set; }
            public ParamXcategories15 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount21
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp21
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats21
        {
            public Completioncount21 completioncount { get; set; }
            public Timestamp21 timestamp { get; set; }
        }

        public class Mobile21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns21
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions21
        {
            public Mobile21 mobile { get; set; }
            public Large21 large { get; set; }
            public Mediumns21 mediumns { get; set; }
            public Xsmall21 xsmall { get; set; }
            public Small21 small { get; set; }
            public Smallns21 smallns { get; set; }
        }

        public class ImageConfig21
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions21 versions { get; set; }
        }

        public class Unlock21
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency15
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award22
        {
            public string code { get; set; }
            public List<Criteria15> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats21 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig21 imageConfig { get; set; }
            public List<Unlock21> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency15> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class E9A43E93ED9A4E44BCF26A4721373657
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award22 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories16
        {
            public string XP0LevelCategories { get; set; }
        }

        public class ParamXcategories16
        {
            public string VehicleCategories { get; set; }
        }

        public class Criteria16
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories16 paramYcategories { get; set; }
            public ParamXcategories16 paramXcategories { get; set; }
            public string paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount22
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp22
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats22
        {
            public Completioncount22 completioncount { get; set; }
            public Timestamp22 timestamp { get; set; }
        }

        public class Mobile22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns22
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions22
        {
            public Mobile22 mobile { get; set; }
            public Large22 large { get; set; }
            public Mediumns22 mediumns { get; set; }
            public Xsmall22 xsmall { get; set; }
            public Small22 small { get; set; }
            public Smallns22 smallns { get; set; }
        }

        public class ImageConfig22
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions22 versions { get; set; }
        }

        public class Unlock22
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency16
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award23
        {
            public string code { get; set; }
            public List<Criteria16> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats22 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig22 imageConfig { get; set; }
            public List<Unlock22> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency16> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class BE271F692127443890EA11149C969898
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public bool completed { get; set; }
            public Award23 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories17
        {
        }

        public class ParamXcategories17
        {
            public string AwardCategories { get; set; }
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria17
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories17 paramYcategories { get; set; }
            public ParamXcategories17 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount23
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp23
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats23
        {
            public Completioncount23 completioncount { get; set; }
            public Timestamp23 timestamp { get; set; }
        }

        public class Mobile23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns23
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions23
        {
            public Mobile23 mobile { get; set; }
            public Large23 large { get; set; }
            public Mediumns23 mediumns { get; set; }
            public Xsmall23 xsmall { get; set; }
            public Small23 small { get; set; }
            public Smallns23 smallns { get; set; }
        }

        public class ImageConfig23
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions23 versions { get; set; }
        }

        public class Unlock23
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency17
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award24
        {
            public string code { get; set; }
            public List<Criteria17> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats23 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig23 imageConfig { get; set; }
            public List<Unlock23> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency17> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories18
        {
            public string WeaponStatCategories { get; set; }
        }

        public class ParamXcategories18
        {
            public string AwardCategories { get; set; }
        }

        public class Criteria18
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories18 paramYcategories { get; set; }
            public ParamXcategories18 paramXcategories { get; set; }
            public string paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount24
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp24
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats24
        {
            public Completioncount24 completioncount { get; set; }
            public Timestamp24 timestamp { get; set; }
        }

        public class Mobile24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns24
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions24
        {
            public Mobile24 mobile { get; set; }
            public Large24 large { get; set; }
            public Mediumns24 mediumns { get; set; }
            public Xsmall24 xsmall { get; set; }
            public Small24 small { get; set; }
            public Smallns24 smallns { get; set; }
        }

        public class ImageConfig24
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions24 versions { get; set; }
        }

        public class Unlock24
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency18
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award25
        {
            public string code { get; set; }
            public List<Criteria18> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats24 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig24 imageConfig { get; set; }
            public List<Unlock24> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency18> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class EA6F45B5DDE045E0A30AE60F724F67DB
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award25 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories19
        {
        }

        public class ParamXcategories19
        {
            public string AwardCategories { get; set; }
        }

        public class Criteria19
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories19 paramYcategories { get; set; }
            public ParamXcategories19 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount25
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp25
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats25
        {
            public Completioncount25 completioncount { get; set; }
            public Timestamp25 timestamp { get; set; }
        }

        public class Mobile25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns25
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions25
        {
            public Mobile25 mobile { get; set; }
            public Large25 large { get; set; }
            public Mediumns25 mediumns { get; set; }
            public Xsmall25 xsmall { get; set; }
            public Small25 small { get; set; }
            public Smallns25 smallns { get; set; }
        }

        public class ImageConfig25
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions25 versions { get; set; }
        }

        public class Unlock25
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency19
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award26
        {
            public string code { get; set; }
            public List<Criteria19> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats25 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig25 imageConfig { get; set; }
            public List<Unlock25> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency19> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class F4AF31D2CB28428A9E349C7908F7F63C
        {
            public string codeNeeded { get; set; }
            public object valueNeededPlain { get; set; }
            public object completed { get; set; }
            public Award26 award { get; set; }
            public object bucketRelativeCompletion { get; set; }
            public object numSecondsLeft { get; set; }
            public object numRoundsLeft { get; set; }
            public int completion { get; set; }
            public object license { get; set; }
            public string unlockType { get; set; }
            public string bucket { get; set; }
            public int actualValue { get; set; }
            public int valueNeeded { get; set; }
        }

        public class ParamYcategories20
        {
            public string KitCategories { get; set; }
        }

        public class ParamXcategories20
        {
            public string AwardCategories { get; set; }
            public string VehicleCategories { get; set; }
        }

        public class Criteria20
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories20 paramYcategories { get; set; }
            public ParamXcategories20 paramXcategories { get; set; }
            public string paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount26
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp26
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats26
        {
            public Completioncount26 completioncount { get; set; }
            public Timestamp26 timestamp { get; set; }
        }

        public class Mobile26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns26
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions26
        {
            public Mobile26 mobile { get; set; }
            public Large26 large { get; set; }
            public Mediumns26 mediumns { get; set; }
            public Xsmall26 xsmall { get; set; }
            public Small26 small { get; set; }
            public Smallns26 smallns { get; set; }
        }

        public class ImageConfig26
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions26 versions { get; set; }
        }

        public class Unlock26
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency20
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award27
        {
            public string code { get; set; }
            public List<Criteria20> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats26 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig26 imageConfig { get; set; }
            public List<Unlock26> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency20> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories21
        {
        }

        public class ParamXcategories21
        {
            public string AwardCategories { get; set; }
            public string WeaponStatCategories { get; set; }
        }

        public class Criteria21
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public string unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public string paramX { get; set; }
            public ParamYcategories21 paramYcategories { get; set; }
            public ParamXcategories21 paramXcategories { get; set; }
            public object paramY { get; set; }
            public string statCode { get; set; }
        }

        public class Completioncount27
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp27
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats27
        {
            public Completioncount27 completioncount { get; set; }
            public Timestamp27 timestamp { get; set; }
        }

        public class Mobile27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns27
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions27
        {
            public Mobile27 mobile { get; set; }
            public Large27 large { get; set; }
            public Mediumns27 mediumns { get; set; }
            public Xsmall27 xsmall { get; set; }
            public Small27 small { get; set; }
            public Smallns27 smallns { get; set; }
        }

        public class ImageConfig27
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions27 versions { get; set; }
        }

        public class Unlock27
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency21
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award28
        {
            public string code { get; set; }
            public List<Criteria21> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats27 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig27 imageConfig { get; set; }
            public List<Unlock27> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency21> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public object license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class ParamYcategories22
        {
        }

        public class ParamXcategories22
        {
        }

        public class Criteria22
        {
            public string descriptionID { get; set; }
            public string statEvent { get; set; }
            public object unit { get; set; }
            public string criteriaType { get; set; }
            public int completionValue { get; set; }
            public object paramX { get; set; }
            public ParamYcategories22 paramYcategories { get; set; }
            public ParamXcategories22 paramXcategories { get; set; }
            public object paramY { get; set; }
            public object statCode { get; set; }
        }

        public class Completioncount28
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Timestamp28
        {
            public string statName { get; set; }
            public string type { get; set; }
        }

        public class Stats28
        {
            public Completioncount28 completioncount { get; set; }
            public Timestamp28 timestamp { get; set; }
        }

        public class Mobile28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Large28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Mediumns28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Xsmall28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Small28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Smallns28
        {
            public string path { get; set; }
            public bool isSprite { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public int width { get; set; }
        }

        public class Versions28
        {
            public Mobile28 mobile { get; set; }
            public Large28 large { get; set; }
            public Mediumns28 mediumns { get; set; }
            public Xsmall28 xsmall { get; set; }
            public Small28 small { get; set; }
            public Smallns28 smallns { get; set; }
        }

        public class ImageConfig28
        {
            public string category { get; set; }
            public string slug { get; set; }
            public string texture { get; set; }
            public Versions28 versions { get; set; }
        }

        public class Unlock28
        {
            public string slot { get; set; }
            public object completion { get; set; }
            public string identifier { get; set; }
            public List<object> requirements { get; set; }
            public object unlockCompletion { get; set; }
            public bool hiddenUntilUnlocked { get; set; }
            public object visibilityLicense { get; set; }
            public string image { get; set; }
            public string descriptionSID { get; set; }
            public bool visible { get; set; }
            public object nameSID { get; set; }
            public string unlockId { get; set; }
            public bool isAccessory { get; set; }
            public string unlockType { get; set; }
            public object valueNeeded { get; set; }
            public string guid { get; set; }
            public string slug { get; set; }
        }

        public class Dependency22
        {
            public int count { get; set; }
            public string code { get; set; }
        }

        public class Award29
        {
            public string code { get; set; }
            public List<Criteria22> criterias { get; set; }
            public object imageDir { get; set; }
            public bool visible { get; set; }
            public string awardRealm { get; set; }
            public int index { get; set; }
            public Stats28 stats { get; set; }
            public bool activeOnCreation { get; set; }
            public string awardType { get; set; }
            public object visibilityLicense { get; set; }
            public string texture { get; set; }
            public object imageName { get; set; }
            public ImageConfig28 imageConfig { get; set; }
            public List<Unlock28> unlocks { get; set; }
            public string stringID { get; set; }
            public object kit { get; set; }
            public string awardGroup { get; set; }
            public List<Dependency22> dependencies { get; set; }
            public string descriptionID { get; set; }
            public object name { get; set; }
            public string license { get; set; }
            public object additionalLicenses { get; set; }
        }

        public class Award
        {
            //public __invalid_type__2608155982C84E5F961D0066D858ADA2 __invalid_name__26081559-82C8-4E5F-961D-0066D858ADA2 { get; set; }
            //public __invalid_type__49D578397FE64C08BD94018EC41AF0C5 __invalid_name__49D57839-7FE6-4C08-BD94-018EC41AF0C5 { get; set; }
            //public __invalid_type__25E7444761D50564F0508D5D1FBD99DC __invalid_name__25E74447-61D5-0564-F050-8D5D1FBD99DC { get; set; }
            //public __invalid_type__862B121CB21A440B80ED87EAB4BB3F0B __invalid_name__862B121C-B21A-440B-80ED-87EAB4BB3F0B { get; set; }
            //public __invalid_type__1C2F96CC940EFA36B7D22BDCA53DDFF7 __invalid_name__1C2F96CC-940E-FA36-B7D2-2BDCA53DDFF7 { get; set; }
            //public __invalid_type__0329EDEA40884BBF9099B6431A8F20B5 __invalid_name__0329EDEA-4088-4BBF-9099-B6431A8F20B5 { get; set; }
            //public AEAA518B925340C2AA18A11F8F2D474C __invalid_name__AEAA518B-9253-40C2-AA18-A11F8F2D474C { get; set; }
            //public A1A5DE0C19A79C842DEB196832622C2A __invalid_name__A1A5DE0C-19A7-9C84-2DEB-196832622C2A { get; set; }
            //public BD68C1FD9B3A4F9EB29D067F53BC92B0 __invalid_name__BD68C1FD-9B3A-4F9E-B29D-067F53BC92B0 { get; set; }
            //public EC1CE991C625461A92014F460767D3D4 __invalid_name__EC1CE991-C625-461A-9201-4F460767D3D4 { get; set; }
            //public C12E6868FC084E258AD01C51201EA69B __invalid_name__C12E6868-FC08-4E25-8AD0-1C51201EA69B { get; set; }
            //public __invalid_type__40A84898626F49769D6ACF8158C68C68 __invalid_name__40A84898-626F-4976-9D6A-CF8158C68C68 { get; set; }
            //public __invalid_type__60583FA6F1584A3EAD6F45862CA5EC8D __invalid_name__60583FA6-F158-4A3E-AD6F-45862CA5EC8D { get; set; }
            //public __invalid_type__2A9F65B98B83CD5E2DAEBA42EBBC721D __invalid_name__2A9F65B9-8B83-CD5E-2DAE-BA42EBBC721D { get; set; }
            //public __invalid_type__55B0B68EC08846F2A4099930D47D2187 __invalid_name__55B0B68E-C088-46F2-A409-9930D47D2187 { get; set; }
            //public __invalid_type__38B599203BA14DA7B7D85C3E4E51F403 __invalid_name__38B59920-3BA1-4DA7-B7D8-5C3E4E51F403 { get; set; }
            //public __invalid_type__33E0AC5332509E6BC64D2F3E4EB6790C __invalid_name__33E0AC53-3250-9E6B-C64D-2F3E4EB6790C { get; set; }
            //public __invalid_type__4D69BFE263184996A15C758AAD7F5746 __invalid_name__4D69BFE2-6318-4996-A15C-758AAD7F5746 { get; set; }
            //public __invalid_type__38C20C39EE43489FAE95DF0519F72409 __invalid_name__38C20C39-EE43-489F-AE95-DF0519F72409 { get; set; }
            //public __invalid_type__8E275DA7935F4891AF45AFF537B71BA5 __invalid_name__8E275DA7-935F-4891-AF45-AFF537B71BA5 { get; set; }
            //public E9A43E93ED9A4E44BCF26A4721373657 __invalid_name__E9A43E93-ED9A-4E44-BCF2-6A4721373657 { get; set; }
            //public BE271F692127443890EA11149C969898 __invalid_name__BE271F69-2127-4438-90EA-11149C969898 { get; set; }
            //public __invalid_type__61079CAAD7EB42758C0215A69B7AAD4B __invalid_name__61079CAA-D7EB-4275-8C02-15A69B7AAD4B { get; set; }
            //public EA6F45B5DDE045E0A30AE60F724F67DB __invalid_name__EA6F45B5-DDE0-45E0-A30A-E60F724F67DB { get; set; }
            //public F4AF31D2CB28428A9E349C7908F7F63C __invalid_name__F4AF31D2-CB28-428A-9E34-9C7908F7F63C { get; set; }
            //public __invalid_type__9C907EADAAA645C096C7C1C47CC978E9 __invalid_name__9C907EAD-AAA6-45C0-96C7-C1C47CC978E9 { get; set; }
            //public __invalid_type__094366000D524037B9C36EA32E9535FF __invalid_name__09436600-0D52-4037-B9C3-6EA32E9535FF { get; set; }
            //public __invalid_type__36CA30260E2546869F956B347A3E7532 __invalid_name__36CA3026-0E25-4686-9F95-6B347A3E7532 { get; set; }
        }

        public class Data
        {
            public int personaId { get; set; }
            public string statsTemplate { get; set; }
            public int platformInt { get; set; }
            public Award award { get; set; }
        }

        public class MainWeaponStat
        {
            public int serviceStars { get; set; }
            public int serviceStarsProgress { get; set; }
            public string code { get; set; }
            public object deaths { get; set; }
            public string categorySID { get; set; }
            public object unlockImageConfig { get; set; }
            public string guid { get; set; }
            public string category { get; set; }
            public int? shotsFired { get; set; }
            public object unlocked { get; set; }
            public object timeEquippedDelta { get; set; }
            public object score { get; set; }
            public object type { get; set; }
            public object imageConfig { get; set; }
            public double? accuracy { get; set; }
            public object startedWith { get; set; }
            public int? headshots { get; set; }
            public int kills { get; set; }
            public List<object> unlocks { get; set; }
            public List<object> kit { get; set; }
            public object duplicateOf { get; set; }
            public string slug { get; set; }
            public int? timeEquipped { get; set; }
            public object killsPerMinuteDelta { get; set; }
            public string name { get; set; }
            public object weapon { get; set; }
            public int? shotsHit { get; set; }
            public object killsDelta { get; set; }
        }

        public class RootObject
        {
            public string type { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
            public List<MainWeaponStat> mainWeaponStats { get; set; }
            public int gameInt { get; set; }
        }
    }
}
