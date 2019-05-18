using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats
{
    public class CharacterStatsUserData : UserData
    {
        public uint CharacterId { get; set; }
        public long Experience { get; set; }
        public long Kama { get; set; }
        public int StatPoint { get; set; }
        public int SpellPoint { get; set; }
        public int Prospecting { get; set; }
        public int ActionPoint { get; set; }
        public int MovementPoint { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Wisdom { get; set; }
        public int Chance { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public static CharacterStatsUserData FromData(StatCollection stats)
        {
            return new CharacterStatsUserData
            {
                Experience = stats.Get(StatType.ExpericenceBoost),
                Kama = stats.Get(StatType.Kama),
                StatPoint = stats.Get(StatType.StatsPoint),
                SpellPoint = stats.Get(StatType.SpellPoint),
                Prospecting = stats.Get(StatType.Prospecting),
                ActionPoint = stats.Get(StatType.ActionPoint),
                MovementPoint = stats.Get(StatType.MovementPoint),
                Strength = stats.Get(StatType.Strength),
                Vitality = stats.Get(StatType.Vitality),
                Wisdom = stats.Get(StatType.Wisdom),
                Chance = stats.Get(StatType.Chance),
                Agility = stats.Get(StatType.Agility),
                Intelligence = stats.Get(StatType.Intelligence)
            };
        }
    }
}
