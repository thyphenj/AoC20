using System;
using System.IO;
using System.Collections.Generic;

namespace _10_AdapterArray
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {
                string str;
                str = "16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4";
                str = "28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3";
                input = str.Replace(" ", "").Split(',');
            }
            List<int> numbers = new List<int>();

            numbers.Add(0);
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }
            numbers.Sort();
            numbers.Add(numbers[numbers.Count - 1] + 3);

            Console.WriteLine("10-AdapterArray\n------------------------- Part 1");

            int[] runs = { 0, 0, 0, 0, 0, 0, 0 };

            int one = 0;
            int thr = 0;

            int run = 1;

            for (int i = 1; i < numbers.Count; i++)
            {
                int n = numbers[i] - numbers[i - 1];
                if (n == 1)
                {
                    one++;
                    run++;
                }
                else
                {
                    thr++;
                    runs[run]++;
                    run = 1;
                }
                //                Console.WriteLine($"{numbers[i - 1],3} {numbers[i],3} {n,3} : {one,2} {thr,3}");
            }
            if (run > 0)
                runs[run]++;

            Console.WriteLine(one * thr);

            Console.WriteLine("------------------------- Part 2");
            //foreach (var i in numbers)
            //    Console.Write(i + "  ");
            //Console.WriteLine();
            //for (int i = 0; i < runs.Length; i++)
            //    Console.WriteLine($"{i} - {runs[i]}");

            UInt64 total = 1;
            for (int i = 0; i < runs[3]; i++) total *= 2;
            for (int i = 0; i < runs[4]; i++) total *= 4;
            for (int i = 0; i < runs[5]; i++) total *= 7;
            for (int i = 0; i < runs[6]; i++) total *= 13;

            Console.WriteLine(total);
        }
    }
}
