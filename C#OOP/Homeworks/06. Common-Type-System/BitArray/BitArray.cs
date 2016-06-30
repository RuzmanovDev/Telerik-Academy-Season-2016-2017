namespace BitArray
{
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray : IEnumerable<int>
    {
        private ulong number;

        public BitArray(ulong number)
        {
            this.number = number;
        }
        private int[] bits;

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.ConvertToBits();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //property to return array of all bits
        public int[] Bits
        {
            get { return this.ConvertToBits(); }
        }

        //method for converting
        private int[] ConvertToBits()
        {
            ulong value = this.number;

            int[] bits = new int[64];
            int counter = 63;

            while (value != 0)
            {
                bits[counter] = (int)value % 2;
                value /= 2;
                counter--;
            }

            do
            {
                bits[counter] = 0;
                counter--;
            }
            while (counter != 0);

            return bits;
        }

        //equals
        public bool Equals(BitArray value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return this.number == value.number;
        }

        public override bool Equals(object obj)
        {
            BitArray temp = obj as BitArray;
            if (temp == null)
                return false;
            return this.Equals(temp);
        }

      
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.number.GetHashCode();
                return result;
            }
        }

        //indexator
        private bool IndexChecker(int index)
        {
            if (index < 0 || index > 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //index to check the bit at position
        public int this[int index]
        {
            get
            {
                if (IndexChecker(index))
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBits();
                return bits[index];
            }
        }

        //== operator
        public static bool operator ==(BitArray first, BitArray second)
        {
            return BitArray.Equals(first, second);
        }

        //!= operator
        public static bool operator !=(BitArray first, BitArray second)
        {
            return !BitArray.Equals(first, second);
        }
    }
}

