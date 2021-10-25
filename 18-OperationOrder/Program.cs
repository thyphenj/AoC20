using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _18_OperationOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false; ;
            string[] input = File.ReadAllLines("Resources/input.txt");
            if (test)
            {
                input = new string[] { "1 + (2 * 3) + (4 * (5 + 6))", "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" };
            }

            Console.WriteLine("18-Operation Order\n----------------------------Part 1");

            long grandTotal = 0L;

            foreach (var str in input)
            {
                string repl = $"({str})";
                var bracketedString = Regex.Match(repl, @"\([^(\)]*\)");
                while (bracketedString.Success)
                {
                    string foundString = bracketedString.Value;
                    string replacementString = EvaluateLtoR(foundString);
                    repl = repl.Replace(foundString, replacementString);
                    bracketedString = Regex.Match(repl, @"\([^(\)]*\)");
                }
                grandTotal += long.Parse(repl);
            }
            Console.WriteLine(grandTotal);

            grandTotal = 0L;

            foreach (var str in input)
            {
                string repl = $"({str})";
                Console.WriteLine(repl);
                var bracketedString = Regex.Match(repl, @"\([^(\)]*\)");
                while (bracketedString.Success)
                {
                    string foundString = bracketedString.Value;
                    string replacementString = EvaluateAdvanced(foundString);
                    repl = repl.Replace(foundString, replacementString);
                    bracketedString = Regex.Match(repl, @"\([^(\)]*\)");
                }
                grandTotal += long.Parse(repl);
            }
            Console.WriteLine(grandTotal);
        }


        public static string EvaluateLtoR(string inputString)
        {
            string retval = inputString;

            Match m = Regex.Match(inputString, @"[0-9]* [+\*] [0-9]*");
            while (m.Success)
            {
                string[] tokens = m.Value.Split(' ');
                long n1 = long.Parse(tokens[0]);
                long n2 = long.Parse(tokens[2]);
                if (tokens[1] == "+")
                    retval = $"{retval.Substring(0, m.Index)}{n1 + n2}{retval.Substring(m.Index + m.Value.Length)}";
                else
                    retval = $"{retval.Substring(0, m.Index)}{n1 * n2}{retval.Substring(m.Index + m.Value.Length)}";

                m = Regex.Match(retval, @"[0-9]* [+\*] [0-9]*");
            }
            return retval.Replace("(", "").Replace(")", "");
        }
        public static string EvaluateAdvanced(string inputString)
        {
            string retval = inputString;

            Match m = Regex.Match(inputString, @"[0-9]* [+] [0-9]*");
            while (m.Success)
            {
                string[] tokens = m.Value.Split(' ');
                long n1 = long.Parse(tokens[0]);
                long n2 = long.Parse(tokens[2]);
                retval = $"{retval.Substring(0, m.Index)}{n1 + n2}{retval.Substring(m.Index + m.Value.Length)}";

                m = Regex.Match(retval, @"[0-9]* [+] [0-9]*");
            }

            m = Regex.Match(retval, @"[0-9]* [*] [0-9]*");
            while (m.Success)
            {
                string[] tokens = m.Value.Split(' ');
                long n1 = long.Parse(tokens[0]);
                long n2 = long.Parse(tokens[2]);
                retval = $"{retval.Substring(0, m.Index)}{n1 * n2}{retval.Substring(m.Index + m.Value.Length)}";

                m = Regex.Match(retval, @"[0-9]* [*] [0-9]*");
            }
            return retval.Replace("(", "").Replace(")", "");
        }
    }
}

