using System.Collections.Generic;

namespace BattlelogMobile.Core.Service
{
    /// <summary>
    /// Since ribbons and medals does not have JSON data for their
    /// names and descriptions, we'll just have to map these values (key is award image name)
    /// </summary>
    public static class AwardNameAndDescriptionMapper
    {
        private static readonly Dictionary<string, KeyValuePair<string, string>> NameAndDescriptionMapper;
        
        static AwardNameAndDescriptionMapper()
        {
            NameAndDescriptionMapper = new Dictionary<string, KeyValuePair<string, string>>
            {
                // Ribbons
                {"r01", new KeyValuePair<string, string>("ASSAULT RIFLE", "In a round, kill 7 enemies with Assault Rifles")},
                {"r02", new KeyValuePair<string, string>("CARBINE", "In a round, kill 7 enemies with Carbines")},
                {"r03", new KeyValuePair<string, string>("LIGHT MACHINE GUN", "In a round, kill 7 enemies with Light Machine Guns")},
                {"r04", new KeyValuePair<string, string>("SNIPER RIFLE", "In a round, kill 7 enemies with Sniper Rifles")},
                {"r05", new KeyValuePair<string, string>("HAND GUN", "In a round, kill 4 enemies with Handguns")},
                {"r06", new KeyValuePair<string, string>("SHOTGUN", "In a round, kill 7 enemies with Shotguns.")},
                {"r07", new KeyValuePair<string, string>("PDW", "In a round, kill 7 enemies with Personal Defense Weapons.")},
                {"r08", new KeyValuePair<string, string>("MELEE", "In a round, kill 4 enemies with Melee Weapons")},
                {"r09", new KeyValuePair<string, string>("DISABLE VEHICLE", "In a round, Disable 4 enemy vehicles")},
                {"r10", new KeyValuePair<string, string>("ANTI VEHICLE", "In a round, Destroy 3 enemy vehicles")},
                {"r11", new KeyValuePair<string, string>("ACCURACY", "In a round, get 5 Headshots")},
                {"r12", new KeyValuePair<string, string>("AVENGER", "In a round, get 2 Avenger Kills")},
                {"r13", new KeyValuePair<string, string>("SAVIOR", "In a round, get 2 Savior Kills")},
                {"r14", new KeyValuePair<string, string>("NEMESIS", "In a round, get 2 Nemesis Kills")},
                {"r15", new KeyValuePair<string, string>("SUPPRESSION", "In a round, get 7 Suppression Assists")},
                {"r16", new KeyValuePair<string, string>("MVP", "In a round, be the Best Player")},
                {"r17", new KeyValuePair<string, string>("MVP 2", "In a round, be the 2nd Best Player")},
                {"r18", new KeyValuePair<string, string>("MVP 3", "In a round, be the 3rd Best Player")},
                {"r19", new KeyValuePair<string, string>("ACE SQUAD", "In a round, be part of the Best Squad")},
                {"r20", new KeyValuePair<string, string>("COMBAT EFFICIENCY", "In a round, get 3 Streak Bonuses")},
                {"r21", new KeyValuePair<string, string>("ANTI EXPLOSIVES", "In a round, Destroy 2 Enemy Explosives")},
                {"r22", new KeyValuePair<string, string>("SQUAD SPAWN", "In a round, get 7 Squad Spawn Bonuses")},
                {"r23", new KeyValuePair<string, string>("SQUAD WIPE", "In a round, get 2 Squad Wipe Bonuses")},
                {"r24", new KeyValuePair<string, string>("TRANSPORT WARFARE", "In a round, kill 4 enemies with Transport Vehicles")},
                {"r25", new KeyValuePair<string, string>("ARMORED WARFARE", "In a round, kill 7 enemies with Land Vehicles")},
                {"r26", new KeyValuePair<string, string>("STATIONARY EMPLACEMENT", "In a round, kill 2 enemies with Emplaced Weapons")},
                {"r27", new KeyValuePair<string, string>("AIR WARFARE", "In a round, kill 6 enemies with Air Vehicles")},
                {"r28", new KeyValuePair<string, string>("M-COM ATTACKER", "In a round, blow up 3 M-COM stations")},
                {"r29", new KeyValuePair<string, string>("M-COM DEFENDER", "In a round, defend 4 M-COM stations")},
                {"r30", new KeyValuePair<string, string>("RUSH WINNER", "Win a Rush round")},
                {"r31", new KeyValuePair<string, string>("CONQUEST WINNER", "Win a Conquest round")},
                {"r32", new KeyValuePair<string, string>("TDM WINNER", "Win a Team Deathmatch round")},
                {"r33", new KeyValuePair<string, string>("SQUAD RUSH WINNER", "Win a Squad Rush round")},
                {"r34", new KeyValuePair<string, string>("SQUAD DEATHMATCH WINNER", "Win a Squad Deathmatch round")},
                {"r35", new KeyValuePair<string, string>("RUSH", "Finish a Rush round")},
                {"r36", new KeyValuePair<string, string>("CONQUEST", "Finish a Conquest round")},
                {"r37", new KeyValuePair<string, string>("TEAM DEATHMATCH", "Finish a Team Deathmatch round")},
                {"r38", new KeyValuePair<string, string>("SQUAD RUSH", "Finish a Squad Rush round")},
                {"r39", new KeyValuePair<string, string>("SQUAD DEATHMATCH", "Finish a Squad Deathmatch round.")},
                {"r40", new KeyValuePair<string, string>("FLAG ATTACKER", "In a round, get 4 Flag Captures")},
                {"r41", new KeyValuePair<string, string>("FLAG DEFENDER", "In a round, get 5 Flag Defends")},
                {"r42", new KeyValuePair<string, string>("RESUPPLY EFFICIENCY", "In a round, get 7 Resupplies")},
                {"r43", new KeyValuePair<string, string>("MAINTENANCE EFFICIENCY", "In a round, get 7 Repairs")},
                {"r44", new KeyValuePair<string, string>("MEDICAL EFFICIENCY", "In a round, get 5 Revives.")},
                {"r45", new KeyValuePair<string, string>("SURVEILLANCE EFFICIENCY", "In a round, get 5 motion Sensor Assists")},
                
                // Medals
                {"m01", new KeyValuePair<string, string>("ASSAULT RIFLE", "Obtain the Assault Rifle Ribbon 50 times")},
                {"m02", new KeyValuePair<string, string>("CARBINE", "Obtain the Carbine Ribbon 50 times")},
                {"m03", new KeyValuePair<string, string>("LIGHT MACHINE GUN", "Obtain the Light Machine Gun Ribbon 50 times")},
                {"m04", new KeyValuePair<string, string>("SNIPER RIFLE", "Obtain the Sniper Rifle Ribbon 50 times")},
                {"m05", new KeyValuePair<string, string>("HANDGUN", "Obtain the Handgun Ribbon 50 times")},
                {"m06", new KeyValuePair<string, string>("SHOTGUN", "Obtain the Shotgun Ribbon 50 times")},
                {"m07", new KeyValuePair<string, string>("PDW", "Obtain the PDW Ribbon 50 times")},
                {"m08", new KeyValuePair<string, string>("MELEE", "Obtain the Melee Ribbon 30 times")},
                {"m09", new KeyValuePair<string, string>("ANTI VEHICLE", "Obtain the Anti Vehicle Ribbon 50 times")},
                {"m10", new KeyValuePair<string, string>("ACCURACY", "Obtain the Accuracy Ribbon 50 times")},
                {"m11", new KeyValuePair<string, string>("AVENGER", "Obtain the Avenger Ribbon 50 times")},
                {"m12", new KeyValuePair<string, string>("SAVIOR", "Obtain the Savior Ribbon 50 times")},
                {"m13", new KeyValuePair<string, string>("NEMESIS", "Obtain the Nemesis Ribbon 50 times")},
                {"m14", new KeyValuePair<string, string>("SUPPRESSION", "Obtain the Suppression Ribbon 50 times")},
                {"m15", new KeyValuePair<string, string>("MVP", "Obtain the MVP Ribbon 50 times")},
                {"m16", new KeyValuePair<string, string>("2ND MVP", "Obtain the 2nd MVP Ribbon 50 times")},
                {"m17", new KeyValuePair<string, string>("3RD MVP", "Obtain the 3rd MVP Ribbon 50 times")},
                {"m18", new KeyValuePair<string, string>("ACE SQUAD", "Obtain the Ace Squad Ribbon 50 times")},
                {"m19", new KeyValuePair<string, string>("COMBAT EFFICIENCY", "Obtain the Combat Efficiency Ribbon 30 times")},
                {"m20", new KeyValuePair<string, string>("TRANSPORT WARFARE", "Obtain the Transport Warfare Ribbon 30 times")},
                {"m21", new KeyValuePair<string, string>("ARMORED WARFARE", "Obtain the Armor Warfare Ribbon 30 times")},
                {"m22", new KeyValuePair<string, string>("AIR WARFARE", "Obtain the Air Warfare Ribbon 30 times")},
                {"m23", new KeyValuePair<string, string>("STATIONARY EMPLACEMENT", "Obtain the Stationary Emplacement Ribbon 30 times")},
                {"m24", new KeyValuePair<string, string>("M-COM ATTACKER", "Obtain the M-COM Attacker Ribbon 30 times")},
                {"m25", new KeyValuePair<string, string>("M-COM DEFENDER", "Obtain the M-COM Defender Ribbon 50 times")},
                {"m26", new KeyValuePair<string, string>("RUSH", "Obtain the Rush Winner Ribbon 50 times")},
                {"m27", new KeyValuePair<string, string>("CONQUEST", "Obtain the Conquest Winner Ribbon 50 times")},
                {"m28", new KeyValuePair<string, string>("TEAM DEATHMATCH", "Obtain the Team Deathmatch Winner Ribbon 50 times")},
                {"m29", new KeyValuePair<string, string>("SQUAD RUSH", "Obtain the Squad Rush Winner Ribbon 50 times")},
                {"m30", new KeyValuePair<string, string>("SQUAD DEATHMATCH", "Obtain the Squad Deathmatch Winner Ribbon 50 times")},
                {"m31", new KeyValuePair<string, string>("FLAG ATTACKER", "Obtain the Flag Attacker Ribbon 50 times")},
                {"m32", new KeyValuePair<string, string>("FLAG DEFENDER", "Obtain the Flag Defender Ribbon 50 times")},
                {"m33", new KeyValuePair<string, string>("RESUPPLY", "Obtain the Resupply Ribbon 50 times")},
                {"m34", new KeyValuePair<string, string>("MAINTENANCE", "Obtain the Maintenance Ribbon 50 times")},
                {"m35", new KeyValuePair<string, string>("MEDICAL", "Obtain the Medical Ribbon 50 times")},
                {"m36", new KeyValuePair<string, string>("SURVEILLANCE", "Obtain the Surveillance Ribbon 50 times")},
                {"m37", new KeyValuePair<string, string>("MORTAR", "Kill 300 enemies with the Mortar")},
                {"m38", new KeyValuePair<string, string>("LASER DESIGNATOR", "Get 300 Damage assists with the Laser Designator")},
                {"m39", new KeyValuePair<string, string>("M18 CLAYMORE", "Kill 300 enemies with the M18 Claymore")},
                {"m40", new KeyValuePair<string, string>("RADIO BEACON", "100 spawns on your Radio Beacon")},
                {"m41", new KeyValuePair<string, string>("US MARINES SERVICE", "Spend 100 hours in the US Marines")},
                {"m42", new KeyValuePair<string, string>("RU ARMY SERVICE", "Spend 100 hours in the RU Army")},
                {"m43", new KeyValuePair<string, string>("ASSAULT SERVICE", "Spend 50 hours as Assault")},
                {"m44", new KeyValuePair<string, string>("ENGINEER SERVICE", "Spend 50 hours as Engineer")},
                {"m45", new KeyValuePair<string, string>("SUPPORT SERVICE", "Spend 50 hours as Support")},
                {"m46", new KeyValuePair<string, string>("RECON SERVICE", "Spend 50 hours as Recon")},
                {"m47", new KeyValuePair<string, string>("TANK SERVICE", "Spend 20 hours in Tanks")},
                {"m48", new KeyValuePair<string, string>("HELICOPTER SERVICE", "Spend 20 hours in Helicopters")},
                {"m49", new KeyValuePair<string, string>("JET SERVICE", "Spend 20 hours in Jets")},
                {"m50", new KeyValuePair<string, string>("STATIONARY SERVICE", "Spend 2 hours in Stationary Weapons")}
            };
        }

        public static KeyValuePair<string, string> Get(string awardCode)
        {
            return NameAndDescriptionMapper.ContainsKey(awardCode) ? 
                NameAndDescriptionMapper[awardCode] : 
                    new KeyValuePair<string, string>("UNKNOWN", "No description available");
        }
    }
}
