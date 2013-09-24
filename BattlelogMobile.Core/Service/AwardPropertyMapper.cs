using System;
using System.Collections.Generic;

namespace BattlelogMobile.Core.Service
{
    /// <summary>
    /// Since ribbons and medals does not have JSON data for their names and descriptions, we'll just have to map these values.
    /// Edit: And now it seems that images are not matching award names anymore, so these were added.
    /// </summary>
    public static class AwardPropertyMapper
    {
        private static readonly Dictionary<string, Tuple<string, string, string>> RibbonMapper;
        private static readonly Dictionary<string, Tuple<string, string, string>> MedalMapper;
        private static readonly Tuple<string, string, string> MappingNotFound = Tuple.Create("UNKNOWN", "No description available", string.Empty);

        static AwardPropertyMapper()
        {
            // Ribbons
            RibbonMapper = new Dictionary<string, Tuple<string, string, string>>
            {
                {"r01", new Tuple<string, string, string>("ASSAULT RIFLE", "In a round, kill 7 enemies with Assault Rifles", "r01.png")},
                {"r02", new Tuple<string, string, string>("CARBINE", "In a round, kill 7 enemies with Carbines", "r02.png")},
                {"r03", new Tuple<string, string, string>("LIGHT MACHINE GUN", "In a round, kill 7 enemies with Light Machine Guns", "r03.png")},
                {"r04", new Tuple<string, string, string>("SNIPER RIFLE", "In a round, kill 7 enemies with Sniper Rifles", "r04.png")},
                {"r05", new Tuple<string, string, string>("HAND GUN", "In a round, kill 4 enemies with Handguns", "r05.png")},
                {"r06", new Tuple<string, string, string>("SHOTGUN", "In a round, kill 7 enemies with Shotguns", "r06.png")},
                {"r07", new Tuple<string, string, string>("PDW", "In a round, kill 7 enemies with Personal Defense Weapons", "r07.png")},
                {"r08", new Tuple<string, string, string>("MELEE", "In a round, kill 4 enemies with Melee Weapons", "r08.png")},
                {"r09", new Tuple<string, string, string>("DISABLE VEHICLE", "In a round, Disable 4 enemy vehicles", "r09.png")},
                {"r10", new Tuple<string, string, string>("ANTI VEHICLE", "In a round, Destroy 3 enemy vehicles", "r10.png")},
                {"r11", new Tuple<string, string, string>("ACCURACY", "In a round, get 5 Headshots", "r11.png")},
                {"r12", new Tuple<string, string, string>("AVENGER", "In a round, get 2 Avenger Kills", "r12.png")},
                {"r13", new Tuple<string, string, string>("SAVIOR", "In a round, get 2 Savior Kills", "r13.png")},
                {"r14", new Tuple<string, string, string>("NEMESIS", "In a round, get 2 Nemesis Kills", "r14.png")},
                {"r15", new Tuple<string, string, string>("SUPPRESSION", "In a round, get 7 Suppression Assists", "r15.png")},
                {"r16", new Tuple<string, string, string>("MVP", "In a round, be the Best Player", "r16.png")},
                {"r17", new Tuple<string, string, string>("MVP 2", "In a round, be the 2nd Best Player", "r17.png")},
                {"r18", new Tuple<string, string, string>("MVP 3", "In a round, be the 3rd Best Player", "r18.png")},
                {"r19", new Tuple<string, string, string>("ACE SQUAD", "In a round, be part of the Best Squad", "r19.png")},
                {"r20", new Tuple<string, string, string>("COMBAT EFFICIENCY", "In a round, get 3 Streak Bonuses", "r20.png")},
                {"r21", new Tuple<string, string, string>("ANTI EXPLOSIVES", "In a round, Destroy 2 Enemy Explosives", "r21.png")},
                {"r22", new Tuple<string, string, string>("SQUAD SPAWN", "In a round, get 7 Squad Spawn Bonuses", "r22.png")},
                {"r23", new Tuple<string, string, string>("SQUAD WIPE", "In a round, get 2 Squad Wipe Bonuses", "r23.png")},
                {"r24", new Tuple<string, string, string>("TRANSPORT WARFARE", "In a round, kill 4 enemies with Transport Vehicles", "r24.png")},
                {"r25", new Tuple<string, string, string>("ARMORED WARFARE", "In a round, kill 7 enemies with Land Vehicles", "r25.png")},
                {"r26", new Tuple<string, string, string>("STATIONARY EMPLACEMENT", "In a round, kill 2 enemies with Emplaced Weapons", "r26.png")},
                {"r27", new Tuple<string, string, string>("AIR WARFARE", "In a round, kill 6 enemies with Air Vehicles", "r27.png")},
                {"r28", new Tuple<string, string, string>("M-COM ATTACKER", "In a round, blow up 3 M-COM stations", "r28.png")},
                {"r29", new Tuple<string, string, string>("M-COM DEFENDER", "In a round, defend 4 M-COM stations", "r29.png")},
                {"r30", new Tuple<string, string, string>("RUSH WINNER", "Win a Rush round", "r30.png")},
                {"r31", new Tuple<string, string, string>("CONQUEST WINNER", "Win a Conquest round", "r31.png")},
                {"r32", new Tuple<string, string, string>("TDM WINNER", "Win a Team Deathmatch round", "r32.png")},
                {"r33", new Tuple<string, string, string>("SQUAD RUSH WINNER", "Win a Squad Rush round", "r33.png")},
                {"r34", new Tuple<string, string, string>("SQUAD DEATHMATCH WINNER", "Win a Squad Deathmatch round", "r34.png")},
                {"r35", new Tuple<string, string, string>("RUSH", "Finish a Rush round", "r35.png")},
                {"r36", new Tuple<string, string, string>("CONQUEST", "Finish a Conquest round", "r36.png")},
                {"r37", new Tuple<string, string, string>("TEAM DEATHMATCH", "Finish a Team Deathmatch round", "r37.png")},
                {"r38", new Tuple<string, string, string>("SQUAD RUSH", "Finish a Squad Rush round", "r38.png")},
                {"r39", new Tuple<string, string, string>("SQUAD DEATHMATCH", "Finish a Squad Deathmatch round.", "r39.png")},
                {"r40", new Tuple<string, string, string>("FLAG ATTACKER", "In a round, get 4 Flag Captures", "r40.png")},
                {"r41", new Tuple<string, string, string>("FLAG DEFENDER", "In a round, get 5 Flag Defends", "r41.png")},
                {"r42", new Tuple<string, string, string>("RESUPPLY EFFICIENCY", "In a round, get 7 Resupplies", "r42.png")},
                {"r43", new Tuple<string, string, string>("MAINTENANCE EFFICIENCY", "In a round, get 7 Repairs", "r43.png")},
                {"r44", new Tuple<string, string, string>("MEDICAL EFFICIENCY", "In a round, get 5 Revives.", "r44.png")},
                {"r45", new Tuple<string, string, string>("SURVEILLANCE EFFICIENCY", "In a round, get 5 motion Sensor Assists", "r451.png")},

                {"tanksuperiorityribbon", new Tuple<string, string, string>("TANK SUPERIORITY", "Finish a Tank Superiority round", "tanksuperiorityribbon.png")},
                {"xp3rnts", new Tuple<string, string, string>("TANK SUPERIORITY", "Finish a Tank Superiority round", "tanksuperiorityribbon.png")},
                {"tanksuperiority2d", new Tuple<string, string, string>("TANK SUPERIORITY WINNER", "Win a Tank Superiority round", "tanksuperiority2d.png")},
                {"xp3rts", new Tuple<string, string, string>("TANK SUPERIORITY WINNER", "Win a Tank Superiority round", "tanksuperiority2d.png")},
                {"conquest_dominationribbon", new Tuple<string, string, string>("DOMINATION", "Finish a Domination round", "conquest_dominationribbon.png")},
                {"xp4rndom", new Tuple<string, string, string>("DOMINATION", "Finish a Domination round", "conquest_dominationribbon.png")},
                {"conquest_domination2d", new Tuple<string, string, string>("DOMINATION WINNER", "Win a Domination round", "conquest_domination2d.png")},
                {"xp3rdom", new Tuple<string, string, string>("DOMINATION WINNER", "Win a Domination round", "conquest_domination2d.png")},
                {"gmribbon", new Tuple<string, string, string>("GUN MASTER", "Finish a Gun Master round", "gmribbon.png")},
                {"xp3rngm", new Tuple<string, string, string>("GUN MASTER", "Finish a Gun Master round", "gmribbon.png")},
                {"gunmaster2d", new Tuple<string, string, string>("GUN MASTER WINNER", "Win a Gun Master round", "gunmaster2d.png")},
                {"xp2rgm", new Tuple<string, string, string>("GUN MASTER WINNER", "Win a Gun Master round", "gunmaster2d.png")},
                {"tdmcqribbon", new Tuple<string, string, string>("TDMCQ", "Finish a TDMCQ round", "tdmcqribbon.png")},
                {"xp2rntdmcq", new Tuple<string, string, string>("TDMCQ", "Finish a TDMCQ round", "tdmcqribbon.png")},
                {"tdmcq2d", new Tuple<string, string, string>("TDMCQ WINNER", "Win a TDMCQ round", "tdmcq2d.png")},
                {"xp2rtdmc", new Tuple<string, string, string>("TDMCQ WINNER", "Win a TDMCQ round", "tdmcq2d.png")},
                {"scavengerribbon", new Tuple<string, string, string>("SCAVENGER", "Finish a Scavenger round", "scavengerribbon.png")},
                {"xp4rnscv", new Tuple<string, string, string>("SCAVENGER", "Finish a Scavenger round", "scavengerribbon.png")},
                {"scavenger2d", new Tuple<string, string, string>("SCAVENGER WINNER", "Win a Scavenger round", "scavenger2d.png")},
                {"xp4rscav", new Tuple<string, string, string>("SCAVENGER WINNER", "Win a Scavenger round", "scavenger2d.png")},
                {"r502", new Tuple<string, string, string>("CAPTURE THE FLAG", "Finish a CTF round", "r502.png")},
                {"xp5r502", new Tuple<string, string, string>("CAPTURE THE FLAG", "Finish a CTF round", "r502.png")},
                {"r501", new Tuple<string, string, string>("CAPTURE THE FLAG WINNER", "Win a CTF round", "r501.png")},
                {"xp5r501", new Tuple<string, string, string>("CAPTURE THE FLAG WINNER", "Win a CTF round", "r501.png")},
                {"xp5_as", new Tuple<string, string, string>("AIR SUPERIORITY", "Finish a Air Superiority round", "xp5_as.png")},
                {"xp5ras", new Tuple<string, string, string>("AIR SUPERIORITY", "Finish a Air Superiority round", "xp5_as.png")},
                {"xp5_aswinner", new Tuple<string, string, string>("AIR SUPERIORITY WINNER", "Win a Air Superiority round", "xp5_aswinner.png")},
                {"xp5asw", new Tuple<string, string, string>("AIR SUPERIORITY WINNER", "Win a Air Superiority round", "xp5_aswinner.png")}
            };
            
            // Medals
            MedalMapper = new Dictionary<string, Tuple<string, string, string>>
            {
                {"m01", new Tuple<string, string, string>("ASSAULT RIFLE", "Obtain the Assault Rifle Ribbon 50 times", "m01.png")},
                {"m02", new Tuple<string, string, string>("CARBINE", "Obtain the Carbine Ribbon 50 times", "m02.png")},
                {"m03", new Tuple<string, string, string>("LIGHT MACHINE GUN", "Obtain the Light Machine Gun Ribbon 50 times", "m03.png")},
                {"m04", new Tuple<string, string, string>("SNIPER RIFLE", "Obtain the Sniper Rifle Ribbon 50 times", "m04.png")},
                {"m05", new Tuple<string, string, string>("HANDGUN", "Obtain the Handgun Ribbon 50 times", "m05.png")},
                {"m06", new Tuple<string, string, string>("SHOTGUN", "Obtain the Shotgun Ribbon 50 times", "m06.png")},
                {"m07", new Tuple<string, string, string>("PDW", "Obtain the PDW Ribbon 50 times", "m07.png")},
                {"m08", new Tuple<string, string, string>("MELEE", "Obtain the Melee Ribbon 30 times", "m08.png")},
                {"m09", new Tuple<string, string, string>("ANTI VEHICLE", "Obtain the Anti Vehicle Ribbon 50 times", "m09.png")},
                {"m10", new Tuple<string, string, string>("ACCURACY", "Obtain the Accuracy Ribbon 50 times", "m10.png")},
                {"m11", new Tuple<string, string, string>("AVENGER", "Obtain the Avenger Ribbon 50 times", "m11.png")},
                {"m12", new Tuple<string, string, string>("SAVIOR", "Obtain the Savior Ribbon 50 times", "m12.png")},
                {"m13", new Tuple<string, string, string>("NEMESIS", "Obtain the Nemesis Ribbon 50 times", "m13.png")},
                {"m14", new Tuple<string, string, string>("SUPPRESSION", "Obtain the Suppression Ribbon 50 times", "m14.png")},
                {"m15", new Tuple<string, string, string>("MVP", "Obtain the MVP Ribbon 50 times", "m15.png")},
                {"m16", new Tuple<string, string, string>("2ND MVP", "Obtain the 2nd MVP Ribbon 50 times", "m16.png")},
                {"m17", new Tuple<string, string, string>("3RD MVP", "Obtain the 3rd MVP Ribbon 50 times", "m17.png")},
                {"m18", new Tuple<string, string, string>("ACE SQUAD", "Obtain the Ace Squad Ribbon 50 times", "m18.png")},
                {"m19", new Tuple<string, string, string>("COMBAT EFFICIENCY", "Obtain the Combat Efficiency Ribbon 30 times", "m19.png")},
                {"m20", new Tuple<string, string, string>("TRANSPORT WARFARE", "Obtain the Transport Warfare Ribbon 30 times", "m20.png")},
                {"m21", new Tuple<string, string, string>("ARMORED WARFARE", "Obtain the Armor Warfare Ribbon 30 times", "m21.png")},
                {"m22", new Tuple<string, string, string>("AIR WARFARE", "Obtain the Air Warfare Ribbon 30 times", "m22.png")},
                {"m23", new Tuple<string, string, string>("STATIONARY EMPLACEMENT", "Obtain the Stationary Emplacement Ribbon 30 times", "m23.png")},
                {"m24", new Tuple<string, string, string>("M-COM ATTACKER", "Obtain the M-COM Attacker Ribbon 30 times", "m24.png")},
                {"m25", new Tuple<string, string, string>("M-COM DEFENDER", "Obtain the M-COM Defender Ribbon 50 times", "m25.png")},
                {"m26", new Tuple<string, string, string>("RUSH", "Obtain the Rush Winner Ribbon 50 times", "m26.png")},
                {"m27", new Tuple<string, string, string>("CONQUEST", "Obtain the Conquest Winner Ribbon 50 times", "m27.png")},
                {"m28", new Tuple<string, string, string>("TEAM DEATHMATCH", "Obtain the Team Deathmatch Winner Ribbon 50 times", "m28.png")},
                {"m29", new Tuple<string, string, string>("SQUAD RUSH", "Obtain the Squad Rush Winner Ribbon 50 times", "m29.png")},
                {"m30", new Tuple<string, string, string>("SQUAD DEATHMATCH", "Obtain the Squad Deathmatch Winner Ribbon 50 times", "m30.png")},
                {"m31", new Tuple<string, string, string>("FLAG ATTACKER", "Obtain the Flag Attacker Ribbon 50 times", "m31.png")},
                {"m32", new Tuple<string, string, string>("FLAG DEFENDER", "Obtain the Flag Defender Ribbon 50 times", "m32.png")},
                {"m33", new Tuple<string, string, string>("RESUPPLY", "Obtain the Resupply Ribbon 50 times", "m33.png")},
                {"m34", new Tuple<string, string, string>("MAINTENANCE", "Obtain the Maintenance Ribbon 50 times", "m34.png")},
                {"m35", new Tuple<string, string, string>("MEDICAL", "Obtain the Medical Ribbon 50 times", "m35.png")},
                {"m36", new Tuple<string, string, string>("SURVEILLANCE", "Obtain the Surveillance Ribbon 50 times", "m36.png")},
                {"m37", new Tuple<string, string, string>("MORTAR", "Kill 300 enemies with the Mortar", "m37.png")},
                {"m38", new Tuple<string, string, string>("LASER DESIGNATOR", "Get 300 Damage assists with the Laser Designator", "m38.png")},
                {"m39", new Tuple<string, string, string>("M18 CLAYMORE", "Kill 300 enemies with the M18 Claymore", "m39.png")},
                {"m40", new Tuple<string, string, string>("RADIO BEACON", "100 spawns on your Radio Beacon", "m40.png")},
                {"m41", new Tuple<string, string, string>("US MARINES SERVICE", "Spend 100 hours in the US Marines", "m41.png")},
                {"m42", new Tuple<string, string, string>("RU ARMY SERVICE", "Spend 100 hours in the RU Army", "m42.png")},
                {"m43", new Tuple<string, string, string>("ASSAULT SERVICE", "Spend 50 hours as Assault", "m43.png")},
                {"m44", new Tuple<string, string, string>("ENGINEER SERVICE", "Spend 50 hours as Engineer", "m44.png")},
                {"m45", new Tuple<string, string, string>("SUPPORT SERVICE", "Spend 50 hours as Support", "m45.png")},
                {"m46", new Tuple<string, string, string>("RECON SERVICE", "Spend 50 hours as Recon", "m46.png")},
                {"m47", new Tuple<string, string, string>("TANK SERVICE", "Spend 20 hours in Tanks", "m47.png")},
                {"m48", new Tuple<string, string, string>("HELICOPTER SERVICE", "Spend 20 hours in Helicopters", "m48.png")},
                {"m49", new Tuple<string, string, string>("JET SERVICE", "Spend 20 hours in Jets", "m49.png")},
                {"m50", new Tuple<string, string, string>("STATIONARY SERVICE", "Spend 2 hours in Stationary Weapons", "m50.png")},

                {"tank_superiority2d", new Tuple<string, string, string>("TANK SUPERIORITY", "Obtain the Tank Superiority Winner Ribbon 50 times", "tank_superiority2d.png")},
                {"xp3mts", new Tuple<string, string, string>("TANK SUPERIORITY", "Obtain the Tank Superiority Winner Ribbon 50 times", "tank_superiority2d.png")},
                {"conquest_domination2d", new Tuple<string, string, string>("DOMINATION", "Obtain the Domination Winner Ribbon 50 times", "conquest_domination2d.png")},
                {"xp2mdom", new Tuple<string, string, string>("DOMINATION", "Obtain the Domination Winner Ribbon 50 times", "conquest_domination2d.png")},
                {"gunmaster2d", new Tuple<string, string, string>("GUN MASTER", "Obtain the Gun Master Ribbon 50 times", "gunmaster2d.png")},
                {"xp2mgm", new Tuple<string, string, string>("GUN MASTER", "Obtain the Gun Master Winner Ribbon 50 times", "gunmaster2d.png")},
                {"tdmcq2s", new Tuple<string, string, string>("TDMCQ", "Obtain the TDMCQ Winner Ribbon 50 times", "tdmcq2s.png")},
                {"xp2mtdmcq", new Tuple<string, string, string>("TDMCQ", "Obtain the TDMCQ Winner Ribbon 50 times", "tdmcq2s.png")},
                {"scavenger2d", new Tuple<string, string, string>("SCAVENGER", "Obtain the Scavenger Winner Ribbon 50 times", "scavenger2d.png")},
                {"xp4mscv", new Tuple<string, string, string>("SCAVENGER", "Obtain the Scavenger Winner Ribbon 50 times", "scavenger2d.png")},
                {"m501", new Tuple<string, string, string>("CAPTURE THE FLAG", "Obtain the CTF Winner Ribbon 50 times", "m501.png")},
                {"xp5m501", new Tuple<string, string, string>("CAPTURE THE FLAG", "Obtain the CTF Winner Ribbon 50 times", "m501.png")},
                {"as", new Tuple<string, string, string>("AIR SUPERIORITY", "Obtain the Air Superiority Winner Ribbon 50 times", "as.png")},
                {"xp5mas", new Tuple<string, string, string>("AIR SUPERIORITY", "Obtain the Air Superiority Winner Ribbon 50 times", "as.png")}
            };
        }

        public static Tuple<string, string, string> Get(string awardCode, string awardGroup)
        {
            if (awardGroup.ToLower().Contains("ribbon"))
                return RibbonMapper.ContainsKey(awardCode) ? RibbonMapper[awardCode] : MappingNotFound;
            return MedalMapper.ContainsKey(awardCode) ? MedalMapper[awardCode] : MappingNotFound;
        }
    }
}
