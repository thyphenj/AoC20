using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _18_OperationOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = true; ;
            string[] input = File.ReadAllLines("Resources/input.txt");
            if (test)
            {
                input = new string[] { "1 + (2 * 3) + (4 * (5 + 6))", "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" };
            }

            Console.WriteLine("18-Operation Order\n----------------------------Part 1");

            long GRANDTOTAL = 0;
            foreach (var line in input)
            {
                List<Token> tokens = new List<Token>();

                int i = 0;
                while (i < line.Length)
                {
                    tokens.Add(new Token(line[i++]));
                    if (i < line.Length && line[i] != ' ')
                    {
                        tokens.Add(new Token(line[i]));
                        i++;
                    }
                    while (i < line.Length && line[i] == ' ')
                        i++;
                }

                long sum = 0;
                for (int j = Token.MaxDepth(); j > 0; j--)
                {
                    List<Token> next = new List<Token>();

                    int from = tokens.FindIndex(a => a.BracketDepth == j) + 1;
                    while (from > 0)
                    {
                        i = 0;
                        sum = 0;
                        while (i < from - 1)
                        {
                            next.Add(tokens[i++]);
                        }

                        {
                            sum = tokens[from++].Value;

                            char op = tokens[from++].Text;
                            while (op == '+' || op == '*')
                            {
                                long nxt = tokens[from++].Value;
                                if (op == '*')
                                    sum *= nxt;
                                else
                                    sum += nxt;
                                op = tokens[from++].Text;
                            }
                            next.Add(new Token(sum, j - 1));
                        }

                        i = from;
                        while (i < tokens.Count)
                        {
                            next.Add(tokens[i++]);
                        }
                        tokens = next;
                        next = new List<Token>();
                        from = tokens.FindIndex(a => a.BracketDepth == j) + 1;
                    }

                }
                i = 0;
                sum = tokens[i++].Value;
                while (i < tokens.Count)
                {
                    int op = tokens[i++].Text;
                    long nxt = tokens[i++].Value;
                    if (op == '+')
                        sum += nxt;
                    else
                        sum *= nxt;
                }
                //Console.WriteLine(sum);
                GRANDTOTAL += sum;
            }

            Console.WriteLine(GRANDTOTAL);


            Console.WriteLine("----------------------------Part 2");

            GRANDTOTAL = 0;
            foreach (var line in input)
            {
                List<Token> tokens = new List<Token>();

                int i = 0;
                while (i < line.Length)
                {
                    tokens.Add(new Token(line[i++]));
                    if (i < line.Length && line[i] != ' ')
                    {
                        tokens.Add(new Token(line[i]));
                        i++;
                    }
                    while (i < line.Length && line[i] == ' ')
                        i++;
                }

                long sum = 0;
                for (int j = Token.MaxDepth(); j > 0; j--)
                {
                    List<Token> next = new List<Token>();

                    int from = tokens.FindIndex(a => a.BracketDepth == j) + 1;
                    while (from > 0)
                    {
                        i = 0;
                        sum = 0;
                        while (i < from - 1)
                        {
                            next.Add(tokens[i++]);
                        }

                        {
                            var prev = tokens[from++];
                            var op = tokens[from++];

                            while (op.Text == '*' || op.Text == '+')
                            {
                                while (op.Text == '*')
                                {
                                    next.Add(prev);
                                    next.Add(op);
                                    prev = tokens[from++];
                                    op = tokens[from++];
                                }

                                sum = prev.Value;
                                while (op.Text == '+')
                                {
                                    sum += tokens[from++].Value;
                                    op = tokens[from++];
                                }
                                next.Add(new Token(sum, j));
                            }


                        }

                    }

                    i = from;
                    while (i < tokens.Count)
                    {
                        next.Add(tokens[i++]);
                    }
                    tokens = next;
                    next = new List<Token>();
                    from = tokens.FindIndex(a => a.BracketDepth == j) + 1;
                }

            }

        }
    }
}

