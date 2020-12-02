using System.IO;
using System.Collections.Generic;

namespace AoC20
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
            foreach ( var val in values)
                System.Console.WriteLine(val);
        }
    }
}
