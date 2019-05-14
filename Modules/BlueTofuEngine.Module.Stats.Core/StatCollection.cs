using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats
{
    public class StatCollection
    {
        private readonly Dictionary<StatType, StatDefinition> _stats;

        public StatCollection()
        {
            _stats = new Dictionary<StatType, StatDefinition>();
            initialize();
        }

        public StatDefinition this[StatType type]
        {
            get
            {
                return _stats[type];
            }
        }

        public IEnumerable<StatDefinition> All => _stats.Values;

        private void initialize()
        {
            Add(StatType.Kama);
            Add(StatType.ExperiencePoints);
            Add(StatType.StatsPoint);
            Add(StatType.SpellPoint);

            Add(StatType.AlignementSide);
            Add(StatType.AlignmentValue);
            Add(StatType.AlignementRank);
            Add(StatType.HonourPoints);

            Add(StatType.Life, 60);
            Add(StatType.MaxLifePoint, 60);
            Add(StatType.EnergyPoint, 1000);
            Add(StatType.MaxEnergyPoints, 1000);
            Add(StatType.ActionPoint, 6);
            Add(StatType.MovementPoint, 3);
            Add(StatType.Initiative, 100);
            Add(StatType.Prospecting, 100);

            Add(StatType.Strength);
            Add(StatType.Vitality);
            Add(StatType.Wisdom);
            Add(StatType.Chance);
            Add(StatType.Agility);
            Add(StatType.Intelligence);

            Add(StatType.Range);
            Add(StatType.Invocation, 1);
            Add(StatType.Reflect);
            Add(StatType.CriticalHit);
            Add(StatType.CriticalMiss);
            Add(StatType.HealBonus);

            Add(StatType.AllDamagesBonus);
            Add(StatType.WeaponDamageBonus);
            Add(StatType.DamageBonusPercent);
            Add(StatType.TrapBonus);
            Add(StatType.TrapBonusPercent);
            Add(StatType.GlyphPower);
            Add(StatType.RunePower);

            Add(StatType.TackleBlock);
            Add(StatType.TackleEvade);
            Add(StatType.PaAttack);
            Add(StatType.PmAttack);
            Add(StatType.DodgePaLost);
            Add(StatType.DodgePmLost);

            Add(StatType.PushDamageBonus);
            Add(StatType.CriticalDamageBonus);
            Add(StatType.NeutralDamageBonus);
            Add(StatType.EarthDamageBonus);
            Add(StatType.WaterDamageBonus);
            Add(StatType.AirDamageBonus);
            Add(StatType.FireDamageBonus);

            Add(StatType.NeutralElementResistPercent);
            Add(StatType.EarthElementResistPercent);
            Add(StatType.WaterElementResistPercent);
            Add(StatType.AirElementResistPercent);
            Add(StatType.FireElementResistPercent);

            Add(StatType.NeutralElementReduction);
            Add(StatType.EarthElementReduction);
            Add(StatType.WaterElementReduction);
            Add(StatType.AirElementReduction);
            Add(StatType.FireElementReduction);

            Add(StatType.PushDamageReduction);
            Add(StatType.CriticalDamageReduction);

            Add(StatType.MeleeDamageDonePercent);
            Add(StatType.MeleeDamageReceivedPercent);
            Add(StatType.RangedDamageDonePercent);
            Add(StatType.RangedDamageReceivedPercent);
            Add(StatType.WeaponDamageDonePercent);
            Add(StatType.WeaponDamageReceivedPercent);
            Add(StatType.SpellDamageDonePercent);
            Add(StatType.SpellDamageReceivedPercent);

            Add(StatType.PermenantDamageBonus);
        }

        public void Add(StatType type, int baseValue = 0)
        {
            if (_stats.ContainsKey(type))
                throw new InvalidOperationException("Stat '" + type + "' already added");
            _stats.Add(type, new StatDefinition(type, baseValue));
        }

        public int Get(StatType type)
        {
            if (_stats.ContainsKey(type))
                return _stats[type].Total;
            return 0;
        }
    }
}
