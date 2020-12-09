using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace _05_BinaryBoarding
{
    class Program
    {
        static void Main(string[] args)
        {

            //------------------------------- Acquire raw input --------------------------------
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            //------------------------------- Massage input --------------------------------
            List<Pass> passes = new List<Pass>();
            {
                foreach (var line in input)
                {
                    passes.Add(new Pass(line));
                }
            }

            System.Console.WriteLine("05-BinaryBoarding\n--------------------- Part 1 ---------------------------");
            {
                int max = 0;
                foreach (var p in passes)
                {
                    if (p.ID > max)
                        max = p.ID;
                }
                Console.WriteLine(max);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
                int counter = 0;
                foreach (var pass in passes.OrderBy(a => a.ID))
                {
                    if (pass.ID != counter)
                    {
                        if (counter != 0)
                            Console.WriteLine($"{pass.ID - 1}");
                        counter = pass.ID;
                    }


                    counter++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------- END ---------------------------");
        }
    }
}
