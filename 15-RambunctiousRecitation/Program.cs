using System;
using System.Linq;
using System.Collections.Generic;

namespace _15_RambunctiousRecitation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;

            string input = "0,8,15,2,12,1,4";
            if (test)
                input = "0,3,6";

            Console.WriteLine("15-RambunctiousRecitation\n----------------------------- Part 1");
            {
                List<long> numbers = new List<long>();

                foreach (var s in input.Split(','))
                {
                    numbers.Add(long.Parse(s));
                }

                long target = 2020;
                long counter = numbers.Count;
                while (counter < target)
                {
                    long n = numbers[numbers.Count - 1];
                    int lastPos = numbers.LastIndexOf(n, numbers.Count - 2);
                    if (lastPos == -1)
                        numbers.Add(0);
                    else
                    {
                        numbers.Add(numbers.Count - 1 - lastPos);
                        //                    numbers.RemoveAt(lastPos);
                    }
                    if (counter % 100000 == 0)
                        Console.Write($"{counter,10} {numbers.Count,10}\r");

                    counter++;
                }
                Console.WriteLine();
                Console.WriteLine(numbers[^1]);
            }
            Console.WriteLine("\n----------------------------- Part 1");
            {
                Dictionary<int, NumClass> numbers = new Dictionary<int, NumClass>();

                int lastNumber = 0;
                int countOfProcessed = 0;
                foreach (var s in input.Split(','))
                {
                    lastNumber = int.Parse(s);
                    numbers.Add(lastNumber, new NumClass(countOfProcessed));
                    countOfProcessed++;
                }

                long target = 30000000;
                while (countOfProcessed < target)
                {
                    int age = 0;
                    if (numbers[lastNumber].PrevPos < 0)
                        age = 0;
                    else
                        age = numbers[lastNumber].LastPos - numbers[lastNumber].PrevPos;
                    if (numbers.ContainsKey(age))
                        numbers[age].Update(countOfProcessed);
                    else
                        numbers.Add(age, new NumClass(countOfProcessed));

                    lastNumber = age;
                    countOfProcessed++;
                }
                Console.WriteLine(lastNumber);
                Console.WriteLine();
            }
        }
    }
}
