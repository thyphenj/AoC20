using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _13_ShuttleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {
                input = new string[] { "939", "7,13,x,x,59,x,31,19" };
            }
            long startTime = long.Parse(input[0]);
            List<int> freqs = new List<int>();
            string[] work = input[1].Split(',');
            foreach (string str in work)
                if (str != "x")
                    freqs.Add(int.Parse(str));
                else
                    freqs.Add(-1);

            Console.WriteLine("13-ShuttleSearch\n-------------------------------- Part 1");

            int timeStamp = freqs.Max() + 1;
            int waitFreq = 0;
            foreach (var f in freqs)
            {
                if (f > 0)
                {
                    int waitTime = (int)((long)f - startTime % (long)f);
                    if (waitTime < timeStamp)
                    {
                        timeStamp = waitTime;
                        waitFreq = f;
                    }
                }
            }
            Console.WriteLine($"{waitFreq * timeStamp}");

            Console.WriteLine("\n-------------------------------- Part 2");

            work = input[1].Split(',');
            List<Number> numbers = new List<Number>();
            int i = 0;
            long N = 1;
            foreach (string str in work)
            {
                Number t;
                if (str[0] != 'x')
                {
                    t = new Number(str, i);
                    numbers.Add(t);
                    N *= t.Mod;
                }
                i++;
            }

            long sum = 0;
            foreach (var num in numbers)
            {
                sum += num.SetYZ(N);
            }
            sum %= N;

            Console.WriteLine(sum);
        }
    }
    class Number
    {
        public int Mod { get; set; }
        public int Bi { get; set; }
        public long Ni { get; set; }
        public int Xi { get; set; }
        public long Product { get; set; }

        public Number(string str, int i)
        {
            Mod = int.Parse(str);
            Bi = Mod - i;
        }
        public long SetYZ(long n)
        {
            Ni = n / Mod;

            long fac = Ni % Mod;
            int x = 1;
            while (fac != 1)
            {
                x++;
                fac += Ni % Mod;
                fac %= Mod;
            }
            Xi = x;
            Product = Bi * Ni * Xi;

            return Product;
        }
        public override string ToString()
        {
            return $"{Mod,3} - {Bi,2} {Ni} {Xi} {Product}";
        }
    }
}
