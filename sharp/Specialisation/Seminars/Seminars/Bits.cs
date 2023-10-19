namespace Seminar1
{
    public interface IBits
    {
        public bool GetBit(int i);
        public void SetBit(bool bit, int index);
    }
    public class IndexException : Exception
    {
        public IndexException(string messge) : base(messge) { }
    }
    public class Bits : IBits
    {
        public Bits(byte b)
        {
            this.Value = b;
            SizeOfValue = sizeof(byte) * 8;
        }

        public Bits(short b)
        {
            this.Value = b;
            SizeOfValue = sizeof(short) * 8;
        }

        public Bits(int b)
        {
            this.Value = b;
            SizeOfValue = sizeof(int) * 8;
        }

        public Bits(long b)
        {
            this.Value = b;
            SizeOfValue = sizeof(long) * 8;
        }

        public long Value { get; set; } = 0;
        private int SizeOfValue { get; set; }

        #region index
        /*
        public bool this[int index]
        {
            get
            {
                if (index > 7 || index < 0)
                    return false;
                return ((Value >> index) & 1) == 1;
            }
            set
            {
                if (index > 7 || index < 0) return;
                if (value == true)
                    Value = (byte)(Value | (1 << index));
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value &= (byte)(Value & mask);
                }
            }
        }
        */
        #endregion

        public static implicit operator long(Bits b) => b.Value;
        public static explicit operator Bits(byte b) => new Bits(b);
        public static explicit operator Bits(short b) => new Bits(b);
        public static explicit operator Bits(int b) => new Bits(b);


        public bool GetBit(int i)
        {
            if (i > SizeOfValue || i < 0)
            {
                throw new IndexException("Значение бита дожнобыть в пределах от 0 до 8");
            }

            return ((Value >> i) & 1) == 1;
        }

        public void SetBit(bool bit, int index)
        {
            if (index > SizeOfValue || index < 0) return;
            if (bit == true)
                Value = (byte)(Value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }
        }
    }
}
