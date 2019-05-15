using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats.GameType
{
    public class CharacterCharacteristicsInformations : NetworkType
    {
        public StatCollection Stats { get; set; }
        public int Level { get; set; }

        public CharacterCharacteristicsInformations()
        {
            ProtocolId = 8;
        }

        public override void Initialize(IEntity entity)
        {
            Stats = entity.Stats().Stats;
            Level = Stats.Get(StatType.Level);
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            var currentLevelMap = GameDataManager<CharacterXpMapping>.Instance.Get(Level);
            var nextLevelMap = GameDataManager<CharacterXpMapping>.Instance.Get(Level + 1);

            writer.WriteVarLong(Stats[StatType.ExperiencePoints].Total);
            writer.WriteVarLong(currentLevelMap.Exp); // Exp level floor
            writer.WriteVarLong(nextLevelMap.Exp); // Exp next level floor
            writer.WriteVarLong(0); // Exp bonus limit

            writer.WriteVarLong(Stats[StatType.Kama].Total); // Kamas

            writer.WriteVarShort((short)Stats[StatType.StatsPoint].Total); // Stats points
            writer.WriteVarShort(0); // Additionnal points
            writer.WriteVarShort((short)Stats[StatType.SpellPoint].Total); // Spells points

            writer.WriteByte(0); // Alignment side
            writer.WriteByte(0); // Alignment value
            writer.WriteByte(0); // Alignment grade
            writer.WriteDouble(0); // Character power
            writer.WriteVarShort(0); // Honor
            writer.WriteVarShort(0); // Honor grade floor
            writer.WriteVarShort(1); // Honor next grade floor
            writer.WriteByte(0); // Aggressable

            writer.WriteVarInt(Stats[StatType.Life].Total); // Life point
            writer.WriteVarInt(Stats[StatType.MaxLifePoint].Total); // Max life point
            writer.WriteVarShort((short)Stats[StatType.EnergyPoint].Total); // Energy point
            writer.WriteVarShort((short)Stats[StatType.MaxEnergyPoints].Total); // Max energy point

            writer.WriteVarShort((short)Stats[StatType.ActionPoint].Total); // Action point
            writer.WriteVarShort((short)Stats[StatType.MovementPoint].Total); // Movement point

            writeCharac(StatType.Initiative, writer); // Initiative
            writeCharac(StatType.Prospecting, writer); // Prospecting
            writeCharac(StatType.ActionPoint, writer); // Action point
            writeCharac(StatType.MovementPoint, writer); // Movement point

            writeCharac(StatType.Strength, writer); // Strength
            writeCharac(StatType.Vitality, writer); // Vitality
            writeCharac(StatType.Wisdom, writer); // Wisdom
            writeCharac(StatType.Chance, writer); // Chance
            writeCharac(StatType.Agility, writer); // Agility
            writeCharac(StatType.Intelligence, writer); // Intelligence

            writeCharac(StatType.Range, writer); // Range
            writeCharac(StatType.Invocation, writer); // Invocation
            writeCharac(StatType.Reflect, writer); // Reflect
            writeCharac(StatType.CriticalHit, writer); // Critical hit
            writer.WriteVarShort(0); // Critical hit weapon
            writeCharac(StatType.CriticalMiss, writer); // Critical miss
            writeCharac(StatType.HealBonus, writer); // Heal bonus

            writeCharac(StatType.AllDamagesBonus, writer); // All damages bonus
            writeCharac(StatType.WeaponDamageBonus, writer); // Weapon damage bonus percent
            writeCharac(StatType.DamageBonusPercent, writer); // Damage bonus percent
            writeCharac(StatType.TrapBonus, writer); // Trap bonus
            writeCharac(StatType.TrapBonusPercent, writer); // Trap bonus percent
            writeCharac(StatType.GlyphPower, writer); // Glyph bonus percent
            writeCharac(StatType.RunePower, writer); // Rune bonus percent
            writeCharac(StatType.PermenantDamageBonus, writer); // Permanent damage percent

            writeCharac(StatType.TackleBlock, writer); // Tackle block
            writeCharac(StatType.TackleEvade, writer); // Tackle evade

            writeCharac(StatType.PaAttack, writer); // PaAttack
            writeCharac(StatType.PmAttack, writer); // PmAttack

            writeCharac(StatType.PushDamageBonus, writer); // Push damage bonus
            writeCharac(StatType.CriticalDamageBonus, writer); // Critical damage bonus
            writeCharac(StatType.NeutralDamageBonus, writer); // Neutral damage bonus
            writeCharac(StatType.EarthDamageBonus, writer); // Earth damage bonus
            writeCharac(StatType.WaterDamageBonus, writer); // Water damage bonus
            writeCharac(StatType.AirDamageBonus, writer); // Air damage bonus
            writeCharac(StatType.FireDamageBonus, writer); // Fire damage bonus

            writeCharac(StatType.DodgePaLost, writer); // Dodge PA lost prob
            writeCharac(StatType.DodgePmLost, writer); // Dodge PM lost prob

            writeCharac(StatType.NeutralElementResistPercent, writer); // Neutral elem resist percent
            writeCharac(StatType.EarthElementResistPercent, writer); // Earth elem resist percent
            writeCharac(StatType.WaterElementResistPercent, writer); // Water elem resist percent
            writeCharac(StatType.AirElementResistPercent, writer); // Air elem resist percent
            writeCharac(StatType.FireElementResistPercent, writer); // Fire elem resist percent

            writeCharac(StatType.NeutralElementReduction, writer); // Neutral elem reduction
            writeCharac(StatType.EarthElementReduction, writer); // Earth elem reduction
            writeCharac(StatType.WaterElementReduction, writer); // Water elem reduction
            writeCharac(StatType.AirElementReduction, writer); // Air elem reduction
            writeCharac(StatType.FireElementReduction, writer); // Fire elem reduction

            writeCharac(StatType.PushDamageReduction, writer); // Push damage reduction
            writeCharac(StatType.CriticalDamageReduction, writer); // Critical damage reduction

            writeCharac(StatType.NeutralElementResistPercent, writer); // PVP Neutral elem resist percent
            writeCharac(StatType.EarthElementResistPercent, writer); // PVP Earth elem resist percent
            writeCharac(StatType.WaterElementResistPercent, writer); // PVP Water elem resist percent
            writeCharac(StatType.AirElementResistPercent, writer); // PVP Air elem resist percent
            writeCharac(StatType.FireElementResistPercent, writer); // PVP Fire elem resist percent
            writeCharac(StatType.NeutralElementReduction, writer); // PVP Neutral elem reduction
            writeCharac(StatType.EarthElementReduction, writer); // PVP Earth elem reduction
            writeCharac(StatType.WaterElementReduction, writer); // PVP Water elem reduction
            writeCharac(StatType.AirElementReduction, writer); // PVP Air elem reduction
            writeCharac(StatType.FireElementReduction, writer); // PVP Fire elem reduction

            writeCharac(StatType.MeleeDamageDonePercent, writer); // Melee damage done percent
            writeCharac(StatType.MeleeDamageReceivedPercent, writer); // Melee damage received percent
            writeCharac(StatType.RangedDamageDonePercent, writer); // Ranged damage done percent
            writeCharac(StatType.RangedDamageReceivedPercent, writer); // Ranged damage received percent
            writeCharac(StatType.WeaponDamageDonePercent, writer); // Weapon damage done percent
            writeCharac(StatType.WeaponDamageReceivedPercent, writer); // Weapon damage received percent
            writeCharac(StatType.SpellDamageDonePercent, writer); // Spell damage done percent
            writeCharac(StatType.SpellDamageReceivedPercent, writer); // Spell damage received percent
        }

        private void writeCharac(StatType type, ICustomDataWriter writer)
        {
            var charac = new CharacterBaseCharacteristic(Stats[type]);
            charac.Serialize(writer);
        }
    }
}
