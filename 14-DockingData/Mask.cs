using System;
namespace _14_DockingData
{
    public class Mask
    {
        public string MASK_RAW;
        public long MASK_KEP;
        public long MASK_SET;
        public long MASK_FLT;

        public Mask(string line)
        {
            if (line.Length > 0)
            {
                MASK_RAW = line;
                MASK_KEP = 0;   //AND with 1 (for mask = 0)
                MASK_SET = 0;   //OR  with 1 (for mask = 1)
                MASK_FLT = 0;

                foreach (var ch in MASK_RAW)
                {
                    MASK_KEP = MASK_KEP * 2 + (long)(ch == '0' ? 1 : 0);
                    MASK_SET = MASK_SET * 2 + (long)(ch == '1' ? 1 : 0);
                    MASK_FLT = MASK_FLT * 2 + (long)(ch == 'X' ? 1 : 0);
                }
                Console.WriteLine("--------------Set MASK");
                Console.WriteLine(MASK_RAW);
                Console.WriteLine(Convert.ToString(MASK_KEP, 2).PadLeft(36, '0'));
                Console.WriteLine(Convert.ToString(MASK_SET, 2).PadLeft(36, '0'));
                Console.WriteLine(Convert.ToString(MASK_FLT, 2).PadLeft(36, '0'));
                Console.WriteLine("--------------");
            }
        }

        public long Apply(long val)
        {
            long work = val;
            Console.WriteLine(Convert.ToString(work, 2).PadLeft(36, '0'));
            work = work & MASK_KEP;
            Console.WriteLine(Convert.ToString(work, 2).PadLeft(36, '0'));
            work = work | MASK_SET;
            Console.WriteLine(Convert.ToString(work, 2).PadLeft(36, '0'));
            Console.WriteLine("--------------");
            return work;
        }

    }
}
