using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _16_TicketTranslation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;

            string[] input = File.ReadAllLines("Resources/input.txt");
            if (test)
                input = new string[] { "class: 1-3 or 5-7",
                    "row: 6-11 or 33-44",
                    "seat: 13-40 or 45-50",
                    "",
                    "your ticket:",
                    "7,1,14",
                    "",
                    "nearby tickets:",
                    "7,3,47",
                    "40,4,50",
                    "55,2,20",
                    "38,6,12" };

            List<Field> fields = new List<Field>();
            int i = 0;
            while (input[i].Length > 0)
            {
                fields.Add(new Field(input[i]));
                i++;
            }

            i += 2;
            Ticket myTicket = new Ticket(input[i]);

            List<Ticket> tickets = new List<Ticket>();
            i += 3;
            while (i < input.Length)
            {
                tickets.Add(new Ticket(input[i]));
                i++;
            }

            Console.WriteLine("16-TicketTranslation\n----------------------- Part 1");

            HashSet<Ticket> badguys = new HashSet<Ticket>();

            long sum = 0;
            foreach (var t in tickets)
                foreach (var f in t.Contents)
                {
                    if (fields.Where(a => a.RangeA.Incl(f)).FirstOrDefault() == null && fields.Where(a => a.RangeB.Incl(f)).FirstOrDefault() == null)
                    {
                        sum += f;
                        badguys.Add(t);
                    }
                }
            Console.WriteLine(sum);

            List<Ticket> goodguys = new List<Ticket>();
            foreach (var t in tickets)
            {
                if (!badguys.Contains(t))
                    goodguys.Add(t);
            }
            Console.WriteLine();
        }
    }
}