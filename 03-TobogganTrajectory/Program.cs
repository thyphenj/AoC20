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

            System.Console.WriteLine("03-TobogganTrajectory\n--------------------- Part 1 ---------------------------");
            {
                int x = 0;
                long cnt = 0;

                foreach (var line in lines)
                {
                    if (line[x] == '#')
                        cnt++;

                    x = (x + 3) % line.Length;
                }
                System.Console.WriteLine(cnt);
            }

            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
                int y = 0;

                int[] x = { 0, 0, 0, 0, 0 };
                long[] cnt = { 0, 0, 0, 0, 0 };

                foreach (var line in lines)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (line[x[i]] == '#')
                            if (i != 4 || y % 2 == 0)
                                cnt[i]++;
                        x[i] = (x[i] + (i * 2 + 1) % 8) % line.Length;
                    }
                    y++;
                }
                System.Console.WriteLine($"{cnt[0] * cnt[1] * cnt[2] * cnt[3] * cnt[4]}");

                System.Console.WriteLine("--------------------- END ---------------------------");
            }
        }
    }
}
