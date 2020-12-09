using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _09_EncodingError
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            // ---------------------- Massage ----------------------------
            int len = input.Length;
            UInt64[] numbers = new UInt64[len];

            for (int i = 0; i < len; i++)
            {
                numbers[i] = UInt64.Parse(input[i]);
            }
            //numbers = new ulong[] { 35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576 };
            len = numbers.Length;

            Console.WriteLine("09-EncodingError\n------------------- Part 1 -----------------------");
            int thisPtr = 25;
            int badPtr = 0;
            UInt64 badNumber = 0;

            while (thisPtr < len)
            {
                badNumber = 0;
                UInt64 num = numbers[thisPtr];
                for (int i = 1; i < 25; i++)
                {
                    UInt64 diff = num - numbers[thisPtr - i];

                    for (int j = i; j <= 25; j++)
                    {
                        if (numbers[thisPtr - j] == diff)
                            badNumber = num;
                    }

                }
                if (badNumber == 0)
                {
                    badPtr = thisPtr;
                    badNumber = num;
                    Console.WriteLine(badNumber);
                    break;
                }
                thisPtr++;
            }

            Console.WriteLine("------------------- Part 2 -----------------------");
            UInt64 sum;
            for (int i = 0; i < len - 1; i++)
            {
                sum = numbers[i];
                for (int j = i + 1; j < len; j++)
                {
                    sum += numbers[j];

                    if (sum == badNumber)
                    {
                        UInt64 min = numbers[i];
                        UInt64 max = min;

                        for (int k = i + 1; k <= j; k++)
                        {
                            if (numbers[k] < min) min = numbers[k];
                            if (numbers[k] > max) max = numbers[k];
                        }

                        Console.WriteLine(min + max);

                        break;
                    }
                }
            }

        }
    }
}
