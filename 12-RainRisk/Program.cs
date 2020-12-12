using System;
using System.IO;
using System.Collections.Generic;

namespace _12_RainRisk
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {
                input = new string[] { "F10", "N3", "F7", "R90", "F11" };
            }

            Console.WriteLine("12-RainRisk\n------------------------- Part 1");
            {
                int x = 0;
                int y = 0;
                int dir = 0;

                foreach (var v in input)
                {
                    int delta = int.Parse(v.Substring(1));
                    switch (v[0])
                    {
                        case 'N':
                            y += delta;
                            break;
                        case 'E':
                            x += delta;
                            break;
                        case 'S':
                            y -= delta;
                            break;
                        case 'W':
                            x -= delta;
                            break;
                        case 'L':
                            dir = (dir + delta) % 360;
                            break;
                        case 'R':
                            dir = (dir - delta + 360) % 360;
                            break;
                        case 'F':
                            {
                                switch (dir)
                                {
                                    case 0:
                                        x += delta;
                                        break;
                                    case 90:
                                        y += delta;
                                        break;
                                    case 180:
                                        x -= delta;
                                        break;
                                    case 270:
                                        y -= delta;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(ManH(x, y));
            }
            Console.WriteLine("\n------------------------- Part 2");
            {
                int x = 0;
                int y = 0;
                int xWay = 10;
                int yWay = 1;

                foreach (var instr in input)
                {
                    int delta = int.Parse(instr.Substring(1));
                    switch (instr[0])
                    {
                        case 'N':
                            yWay += delta;
                            break;
                        case 'E':
                            xWay += delta;
                            break;
                        case 'S':
                            yWay -= delta;
                            break;
                        case 'W':
                            xWay -= delta;
                            break;
                        case 'L':
                        case 'R':
                            Rotate(x, y, ref xWay, ref yWay, instr);
                            break;
                        case 'F':
                            int xDelta = xWay - x;
                            int yDelta = yWay - y;
                            for (int i = 0; i < delta; i++)
                            {
                                x += xDelta;
                                y += yDelta;
                            }
                            xWay = x + xDelta;
                            yWay = y + yDelta;
                            break;
                        default:
                            break;
                    }
                    //                    Console.WriteLine($"[{instr[0]}{instr.Substring(1),4}] pos=({x,5},{y,5}) way=({xWay,5} {yWay,5})");
                }
                Console.WriteLine(ManH(x, y));
            }
        }
        static int ManH(int x, int y)
        {
            return (x < 0 ? -x : x) + (y < 0 ? -y : y);
        }

        static void Rotate(int x, int y, ref int xWay, ref int yWay, string dir)
        {
            // find offset amd curr segment
            int xDelta = xWay - x;
            int yDelta = yWay - y;
            int seg = (xDelta > 0 ? (yDelta > 0 ? 0 : 3) : (yDelta > 0 ? 1 : 2));

            //grab the absolute values
            xDelta = Math.Abs(xDelta);
            yDelta = Math.Abs(yDelta);

            // find how many anticlock segments to turn
            int rot = int.Parse(dir.Substring(1)) / 90;
            if (dir[0] == 'R')
                rot = 4 - rot;

            // an odd number of turns means deltas are transposed
            if (rot % 2 == 1)
            {
                int t = xDelta;
                xDelta = yDelta;
                yDelta = t;
            }

            // depending which segment we end up in
            switch ((seg + rot) % 4)
            {
                case 0:
                    xWay = x + xDelta;
                    yWay = y + yDelta;
                    break;
                case 1:
                    xWay = x - xDelta;
                    yWay = y + yDelta;
                    break;
                case 2:
                    xWay = x - xDelta;
                    yWay = y - yDelta;
                    break;
                case 3:
                    xWay = x + xDelta;
                    yWay = y - yDelta;
                    break;
            }

        }
    }
}
