using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Stats
{
    public class StatDefinition
    {
        public StatType Type { get; set; }

        public int Base { get; private set; }
        public int Additionnal { get; private set; }
        public int Equipment { get; private set; }
        public int AlignGift { get; private set; }
        public int Context { get; private set; }

        public int Total
        {
            get => TotalWithoutContext + Context;
        }

        public int TotalWithoutContext
        {
            get => Base + Additionnal + Equipment + AlignGift;
        }

        public StatDefinition(StatType type, int baseValue = 0)
        {
            Type = type;
            Base = baseValue;
        }

        public void Set(StatPartType partType, int value)
        {
            switch (partType)
            {
                case StatPartType.Base:
                    Base = value;
                    break;
                case StatPartType.Additionnal:
                    Additionnal = value;
                    break;
                case StatPartType.Equipment:
                    Equipment = value;
                    break;
                case StatPartType.AlignGift:
                    AlignGift = value;
                    break;
                case StatPartType.Context:
                    Context = value;
                    break;
            }
        }

        public void Add(StatPartType partType, int value)
        {
            switch (partType)
            {
                case StatPartType.Base:
                    Base += value;
                    break;
                case StatPartType.Additionnal:
                    Additionnal += value;
                    break;
                case StatPartType.Equipment:
                    Equipment += value;
                    break;
                case StatPartType.AlignGift:
                    AlignGift += value;
                    break;
                case StatPartType.Context:
                    Context += value;
                    break;
            }
        }
    }
}
