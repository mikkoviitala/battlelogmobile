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
                // New from Battlefield 4 
                {"870-MCS", "870 MCS"},
                {"AA-MINE", "AA MINE"},
                {"ACE-21-CQB", "ACE 21 CQB"},
                {"ACE-23", "ACE 23"},
                {"ACE-52-CQB", "ACE 52 CQB"},
                {"ACE-53-SV", "ACE 53 SV"},
                {"AK-5C", "AK 5C"},
                {"AMR-2-CQB", "AMR-2 CQB"},
                {"AMR-2-MID", "AMR-2 MID"},
                {"AUG-A3", "AUG A3"},
                {"C4-EXPLOSIVE", "C4 EXPLOSIVE"},
                {"CARBON-FIBER", "CARBON FIBER"},
                {"COMPACT-45", "COMPACT 45"},
                {"FGM-172-SRAW", "SRAW"},
                {"GOL-MAGNUM", "GOL MAGNUM"},
                {"HAND-FLARE", "HAND FLARE"},
                {"HAWK-12G", "HAWK 12G"},
                {"M136-CS", "M136 CS"},
                {"M18-SMOKE", "M18 SMOKE"},
                {"M26-DART", "M26 DART"},
                {"M26-FRAG", "M26 FRAG"},
                {"M26-SLUG", "M26 SLUG"},
                {"M2-SLAM", "M2 SLAM"},
                {"M320-3GL", "M320 3GL"},
                {"M320-DART", "M320 DART"},
                {"M320-FB", "M320 FB"},
                {"M320-HE", "M320 HE"},
                {"M320-LVG", "M320 LVG"},
                {"M320-SMK", "M320 SMOKE"},
                {"M32-MGL", "M32 MGL"},
                {"M34-INCENDIARY", "M34 INCENDIARY"},
                {"M412-REX", "M412 REX"},
                {"M67-FRAG", "M67 FRAG"},
                {"M82A3-CQB", "M82A3 CQB"},
                {"M82A3-MID", "M82A3 MID"},
                {"M84-FLASHBANG", "M84 FLASHBANG"},
                {"MBT-LAW", "MBT LAW"},
                {"MK153-SMAW", "SMAW"},
                {"RGO-IMPACT", "RGO IMPACT"},
                {"SCAR-H-SV", "SCAR-H SV"},
                {"SCOUT-ELITE", "SCOUT ELITE"},
                {"SHORTY-12G", "SHORTY 12G"},
                {"U-100-MK5", "U-100 MK5"},
                {"USAS-12-FLIR", "USAS-12 FLIR"},
                {"UTS-15", "UTS 15"},
                {"V40-MINI", "V40 MINI"},
                {"XM25-AIRBURST", "XM25 AIRBURST"},
                {"XM25-DART", "XM25 DART"},
                {"XM25-SMOKE", "XM25 SMOKE"},

                {"OLD-CANNON", "OLD CANNON"},
                {"LD-2000-AA", "LD-2000 AA"},
                {"50-CAL", ".50 CAL"},
                {"A10-WARTHOG", "A10 WARTHOG"},
                {"AA-MINE1", "AA MINE"},
                {"AC-130-GUNSHIP", "AC-130 GUNSHIP"},
                {"HJ-8-LAUNCHER", "HJ-8 LAUNCHER"},
                {"HJ-8-LAUNCHER1", "HJ-8 LAUNCHER"},
                {"M224-MORTAR1", "M224 MORTAR"},
                {"Q-5-FANTAN", "Q-5 FANTAN"},
                {"TYPE-95-AA", "TYPE 95 AA"},
                {"TYPE-99-MBT", "TYPE 99 MBT"},
                {"UCAV1", "UCAV"},
                {"Z-11W1", "Z-11W"},
                {"Z-9-HAITUN", "Z-9 HAITUN"},

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
                {"SA-18-IGLA", "IGLA"},
                {"TYPE-88-LMG", "TYPE88 LMG"},
                {"ASSAULT-M320-LVG", "M320"},
                {"XBOW-SCOPED", "XBOW SCOPED"},

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
                {"QUAD-BIKE", "QUAD BIKE"},

                // Gadget slug -> Display name
                {"C4-EXPLOSIVES", "C4 EXPLOSIVES"},
                {"EOD-BOT", "EOD BOT"},
                {"M15-AT-MINE", "M15 AT MINE"},
                {"M18-CLAYMORE", "M18 CLAYMORE"},
                {"M224-MORTAR", "M224 MORTAR"},
                {"M67-GRENADE", "M67 GRENADE"},
                {"AMMO-BOX", "AMMO BOX"},
                {"RADIO-BEACON", "RADIO BEACON"},
                {"REPAIR-TOOL", "REPAIR TOOL"},
                {"MEDIC-KIT", "MEDIC KIT"}
            };
        }

        public static string Get(string itemIdentifier)
        {
            return Mapper.ContainsKey(itemIdentifier) ? Mapper[itemIdentifier] : itemIdentifier;
        }
    }
}
