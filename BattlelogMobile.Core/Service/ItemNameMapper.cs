using System.Collections.Generic;

namespace BattlelogMobile.Core.Service
{
    /// <summary>
    /// Maps item names/slugs/whatever to more meaningfull display names.
    /// If no match is found, the variable passed in is returned unmodified.
    /// </summary>
    public static class ItemNameMapper
    {
        private static readonly Dictionary<string, string> Mapper;

        static ItemNameMapper()
        {
            Mapper = new Dictionary<string, string>
            {
                // Weapon slug -> Display name
                {"44-MAGNUM", ".44 MAGNUM"},
                {"44-SCOPED", ".44 SCOPED"},
                {"AS-VAL", "AS VAL"},
                {"FGM-148-JAVELIN", "JAVELIN"},
                {"FIM-92-STINGER", "STINGER"},
                {"G17C-SUPP", "G17C SUPP."},
                {"G18-SUPP", "G18 SUPP."},
                {"HK53", "G53"},
                {"M1911-SUPP", "M1911 SUPP."},
                {"M1911-TACT", "M1911 TACT."},
                {"M1911-S-TAC", "M1911 S-TAC"},
                {"M26-MASS", "M26 MASS"},
                {"M27-IAR", "M27 IAR"},
                {"M39-EMR", "M39 EMR"},
                {"M9-SUPP", "M9 SUPP."},
                {"M9-TACT", "M9 TACT."},
                {"MK11-MOD-0", "MK11 MOD 0"},
                {"MP412-REX", "MP412 REX"},
                {"MP443-SUPP", "MP443 SUPP."},
                {"MP443-TACT", "MP443 TACT."},
                {"PKP-PECHENEG", "PKP PECHENEG"},
                {"SAIGA-12K", "SAIGA 12K"},
                {"SA-18-IGLA", "SA18 IGLA"},
                {"TYPE-88-LMG", "TYPE88 LMG"},

                // Vehicle slug -> DisplayName
                {"9K22-TUNGUSKA-M", "9K22 TUNGUSKA-M"},
                {"9M133-KORNET-LAUNCHER", "9M133 KORNET"},
                {"A-10-THUNDERBOLT", "A-10 THUNDERBOLT"},
                {"AAV-7A1-AMTRAC", "AAV-7A1 AMTRAC"},
                {"AH-1Z-VIPER", "AH-1Z VIPER"},
                {"AH-6J-LITTLE-BIRD", "AH-6J LITTLEBIRD"},
                {"CENTURION-C-RAM", "CENTURION C-RAM"},
                {"F-A-18E-SUPER-HORNET", "F/A-18E SUPER HORNET"},
                {"GAZ-3937-VODNIK", "GAZ-3937 VODNIK"},
                {"GROWLER-ITV", "GROWLER ITV"},
                {"KA-60-KASATKA", "KA-60 KASATKA"},
                {"M1114-HMMWV", "M1114 HMMWV"},
                {"MI-28-HAVOC", "MI-28 HAVOC"},
                {"M1-ABRAMS", "M1 ABRAMS"},
                {"M220-TOW-LAUNCHER", "M220 TOW"},
                {"RHIB-BOAT", "RHIB BOAT"},
                {"SKID-LOADER", "SKID LOADER"},
                {"SU-25TM-FROGFOOT", "SU-25TM FROGFOOT"},
                {"SU-35BM-FLANKER-E", "SU-35BM FLANKER-E"},
                {"UH-1Y-VENOM", "UH-1Y VENOM"},
                {"VDV-BUGGY", "VDV BUGGY"},

                // Gadget slug -> Display name
                {"C4-EXPLOSIVES", "C4 EXPLOSIVES"},
                {"EOD-BOT", "EOD BOT"},
                {"M15-AT-MINE", "M15 AT MINE"},
                {"M18-CLAYMORE", "M18 CLAYMORE"},
                {"M224-MORTAR", "M224 MORTAR"},
                {"M67-GRENADE", "M67 GRENADE"}
            };
        }

        public static string Get(string itemIdentifier)
        {
            return Mapper.ContainsKey(itemIdentifier) ? Mapper[itemIdentifier] : itemIdentifier;
        }
    }
}
