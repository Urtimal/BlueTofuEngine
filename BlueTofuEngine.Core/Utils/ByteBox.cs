using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core
{
    public class ByteBox
    {
        public byte Value { get; set; }

        public ByteBox(byte value = 0)
        {
            Value = value;
        }

        public bool this[int pos]
        {
            get
            {
                return (Value & (1 << pos)) != 0;
            }
            set
            {
                if (value)
                    Value |= (byte)(1 << pos);
            }
        }
    }
}
