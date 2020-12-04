using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _04_PassportProcessing
{
    class Program
    {
        static void Main(string[] args)
        {

            //------------------------------- Acquire raw input --------------------------------
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            //------------------------------- Massage input --------------------------------
            List<PassPort> passports = new List<PassPort>();
            {
                PassPort p = new PassPort();

                foreach (var line in input)
                {
                    if (line.Length > 0)
                    {
                        string[] fields = line.Split(' ');
                        foreach (var field in fields)
                        {
                            p.AddField(field);
                        }
                    }
                    else
                    {
                        passports.Add(p);
                        p = new PassPort();
                    }
                }
                passports.Add(p);
            }

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            {
                System.Console.WriteLine(passports.Where(a => a.AreFieldsPresent()).Count());
                System.Console.WriteLine();
            }
            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
                System.Console.WriteLine(passports.Where(a => a.AreFieldsPresent() && a.AreFieldsValid()).Count());
                System.Console.WriteLine();
                System.Console.WriteLine("--------------------- END ---------------------------");
            }
        }
    }
}
