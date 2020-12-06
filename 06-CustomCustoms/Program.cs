using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace _06_CustomCustoms
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------- Acquire raw input --------------------------------
            string input = File.ReadAllText(@"Resources/input.txt");

            string[] groups = input.Split("\n\n");

            Console.WriteLine("------------------- Part 1 -----------------------");

            int total = 0;
            foreach (var group in groups)
            {
                HashSet<char> characters = new HashSet<char>();
                foreach (var line in group.Split('\n'))
                {
                    foreach (char ch in line)
                    {
                        characters.Add(ch);
                    }
                }
                total += characters.Count;
            }
            Console.WriteLine(total);
            Console.WriteLine();

            Console.WriteLine("------------------- Part 2 -----------------------");
            HashSet<char> everything = new HashSet<char>();
            for (int i = 0; i < 26; i++)
            {
                everything.Add(Convert.ToChar('a' + i));
            }
            total = 0;
            foreach (var group in groups)
            {
                HashSet<char> prev = everything;
                HashSet<char> next = new HashSet<char>();

                foreach (var line in group.Split('\n'))
                {
                    foreach (var ch in line)
                    {
                        if (prev.Contains(ch))
                        {
                            next.Add(ch);
                        }
                    }
                    prev = next;
                    next = new HashSet<char>();
                }
                total += prev.Count;
            }
            Console.WriteLine(total);
            Console.WriteLine();
        }
    }
}