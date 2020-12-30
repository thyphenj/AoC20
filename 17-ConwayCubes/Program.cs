using System;
using System.IO;

namespace _17_ConwayCubes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = true;
            string[] input = File.ReadAllLines("Resources/input.txt");
            if (test)
                input = new string[] { ".#.", "..#", "###" };

            //put it in the blob
            Space XYZ = new Space();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    XYZ.Set(x, y, 0, input[y][x]);
                }
            }

            Console.WriteLine("17-ConwayCubes\n------------------------------- Part 1");

            Console.WriteLine(XYZ);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"-------------------- {i}");

                XYZ.Iterate();
                Console.WriteLine(XYZ);
            }

            Console.WriteLine(XYZ.Accumulate());

            Console.WriteLine("\n------------------------------- Part 2");
        }
    }
}
