using System;
using System.Collections.Generic;

namespace _14_DockingData
{
    public class Mask
    {
        public string MASK_RAW;
        public long MASK_KEP;
        public long MASK_SET;
        public long MASK_FLT;

        private List<long> toggler;

        public Mask(string line)
        {
            if (line.Length > 0)
            {
                MASK_RAW = line;
                MASK_KEP = 0;   //AND with 1 (for mask = 0)
                MASK_SET = 0;   //OR  with 1 (for mask = 1)
                MASK_FLT = 0;

                toggler = new List<long>();

                int i = 0;
                foreach (var ch in MASK_RAW)
                {
                    MASK_KEP = MASK_KEP * 2 + (long)(ch == '0' ? 1 : 0);
                    MASK_SET = MASK_SET * 2 + (long)(ch == '1' ? 1 : 0);
                    MASK_FLT = MASK_FLT * 2 + (long)(ch == 'X' ? 1 : 0);
                    if (ch == 'X')
                    {
                        toggler.Add((long)Math.Pow(2, 35 - i));
                    }
                    i++;
                }
            }
        }

        public List<long> Apply(long val)
        {
            List<long> retval = new List<long>();

            long baseVal = val;

            baseVal &= MASK_KEP;
            baseVal |= MASK_SET;

            retval.Add(baseVal);

            int bitmapLen = (int)Math.Pow(2, toggler.Count);

            for (uint bitmap = 0; bitmap < bitmapLen; bitmap++)
            {
                long nextVal = baseVal;

                int bit = 1;
                for (int i = 0; i < toggler.Count; i++)
                {
                    if ((bitmap & bit) == bit) nextVal |= toggler[i];
                    bit <<= 1;
                }
                retval.Add(nextVal);
            }
            return retval;
        }

    }
}
