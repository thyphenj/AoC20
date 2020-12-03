using System.IO;
using System.Collections.Generic;

namespace _03_TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines(@"Resources/input.txt"))
            {
                lines.Add(line);
            }

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");

            int cnt = 0;
            int x = 0;
            foreach (var line in lines)
            {
                if (line[x] == '#')
                    cnt++;
                x = (x + 3) % line.Length;
            }
            System.Console.WriteLine(cnt);

            //------------------------------ Part 2 ------------------------------------
             System.Console.WriteLine("--------------------- Part 2 ---------------------------");

            long cnt1 = 0;
            long cnt2 = 0;
            long cnt3 = 0;
            long cnt4 = 0;
            long cnt5 = 0;
            int x1 = 0;
            int x2 = 0;
            int x3 = 0;
            int x4 = 0;
            int x5 = 0;
            int y = 0;
            foreach (var line in lines)
            {
                if (line[x1] == '#')
                    cnt1++;
                if (line[x2] == '#')
                    cnt2++;
                if (line[x3] == '#')
                    cnt3++;
                if (line[x4] == '#')
                    cnt4++;
                if (line[x5] == '#' && y%2 == 0)
                    cnt5++;

                x1 = (x1 + 1) % line.Length;
                x2 = (x2 + 3) % line.Length;
                x3 = (x3 + 5) % line.Length;
                x4 = (x4 + 7) % line.Length;
                x5 = (x5 + 1) % line.Length;
                y++;
            }
            long prod = cnt1 * cnt2 * cnt3 * cnt4 * cnt5;
                System.Console.WriteLine($"{cnt1,3} {cnt2,3} {cnt3,3} {cnt4,3} {cnt5,3} - {prod}");

            System.Console.WriteLine("--------------------- END ---------------------------");
        }
    }
}
