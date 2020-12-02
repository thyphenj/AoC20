using System.IO;
using System.Collections.Generic;

namespace _02_PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pword> values = new List<Pword>();

            foreach (string line in File.ReadLines(@"Resources/input.txt"))
            {
                values.Add(new Pword(line));
            }

            int cnt;

            //------------------------------ Part 1 ------------------------------------
            cnt = 0;
            foreach  ( var val in values)
            {
                if (val.ValidCount())
                {
                    cnt++;
                    System.Console.WriteLine(val.ToString());
                }
            }
            System.Console.WriteLine(cnt);

            //------------------------------ Part 2 ------------------------------------
            cnt = 0;
            foreach (var val in values)
            {
                if (val.ValidPosition())
                {
                    cnt++;
                    System.Console.WriteLine(val.ToString());
                }
            }
            System.Console.WriteLine(cnt);
        }
    }
}
