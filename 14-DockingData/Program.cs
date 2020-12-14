using System;
using System.Collections.Generic;
using System.IO;

namespace _14_DockingData
{
    class Program
    {
        static string MASK_RAW;
        static long MASK_LOSE;
        static long MASK_KEEP;
        static long MASK_MEMR;

        static void Main(string[] args)
        {
            bool test = true;
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            Console.WriteLine("14-DockingData\n-------------------------------- Part 1");
            if (test)
                input = new string[] {
                    "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                    "mem[8] = 11",
                    "mem[7] = 101",
                    "mem[8] = 0" };

            Dictionary<long, long> memory = new Dictionary<long, long>();

            foreach (var line in input)
            {
                if (line.Substring(0, 7) == "mask = ")
                {
                    MASK_RAW = line.Substring(7);

                    MASK_KEEP = 0;
                    MASK_LOSE = 0;
                    foreach (var ch in MASK_RAW)
                    {
                        MASK_KEEP = MASK_KEEP * 2 + (long)(ch == '0' ? 0 : 1);
                        MASK_LOSE = MASK_LOSE * 2 + (long)(ch == '1' ? 1 : 0);
                    }
                }
                else
                {
                    string[] work = line.Split(" = ");
                    long val = (long.Parse(work[1]) & MASK_KEEP) | MASK_LOSE;

                    work[0] = work[0].Substring(0, work[0].Length - 1);
                    work[0] = work[0].Substring(4);
                    long mem = long.Parse(work[0]);
                    if (memory.ContainsKey(mem))
                        memory[mem] = val;
                    else
                        memory.Add(mem, val);
                }
            }

            long sum = 0;
            foreach (var m in memory)
                sum += m.Value;
            Console.WriteLine(sum);

            Console.WriteLine("\n-------------------------------- Part 2");
            if (test)
            {
                input = new string[] {
                    "mask = 000000000000000000000000000000X1001X",
                    "mem[42] = 100",
                    "mask = 00000000000000000000000000000000X0XX",
                    "mem[26] = 1" };
            }
            memory = new Dictionary<long, long>();
            Mask mask = new Mask("");

            foreach (var line in input)
            {
                if (line.Substring(0, 7) == "mask = ")
                {
                    mask = new Mask(line.Substring(7));
                }
                else
                {
                    string[] work = line.Split(" = ");

                    long val = long.Parse(work[1]);
                    long mem = long.Parse(work[0].Substring(4, work[0].Length - 5));
                    mem = mask.Apply(mem);

                    if (memory.ContainsKey(mem))
                        memory[mem] = val;
                    else
                        memory.Add(mem, val);
                }
            }

            sum = 0;
            foreach (var m in memory)
                sum += m.Value;
            Console.WriteLine(sum);

        }
        static long ApplyBitMask(long val)
        {
            return ((val & MASK_KEEP) | MASK_LOSE);
        }

    }
}
