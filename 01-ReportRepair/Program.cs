using System.IO;
using System.Collections.Generic;

namespace _01_ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>();

            foreach (string line in File.ReadLines(@"Resources/input.txt"))
            {
                values.Add(int.Parse(line));
            }

            values.Sort();

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            for (var i = 0 ; i <values.Count && values[i]*2 < 2020; i++)
            {
                int j = 2020 - values[i];
                if (values.Contains(j))
                {
                    System.Console.WriteLine($"{values[i],4} {j,4}      - {values[i] * j,10}");
                }
            }
            System.Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            for ( int i = 0; i < values.Count; i++)
            {
                for (int j = i+1; j < values.Count && values[i]+values[j]*2<2020; j++)
                {
                    int k = 2020 - values[i] - values[j];
                    if (values.Contains(k))
                    {
                        System.Console.WriteLine($"{values[i],4} {values[j],4} {k,4} - {values[i] * values[j] * k,10}");
                    }
                }
            }
            System.Console.WriteLine();

            System.Console.WriteLine("--------------------- END ---------------------------");

        }
    }
}
