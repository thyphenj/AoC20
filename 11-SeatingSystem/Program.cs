using System;
using System.IO;
using System.Collections.Generic;

namespace _11_SeatingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            if (test)
            {
                input = new string[] {
                    "L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"};
            }

            int maxX = input[0].Length;
            int maxY = input.Length;

            Cell[,] Grid1;
            Console.WriteLine("11-SeatingSystem\n------------------------- Part 1");

            Grid1 = new Cell[maxX, maxY];

            for (int y = 0; y < maxY; y++)
            {
                string line = input[y];
                for (int x = 0; x < maxX; x++)
                {
                    Grid1[x, y] = new Cell(line[x], x, y);
                }
            }

            int lasttime = -10;
            int occupied = 0;

            while (occupied != lasttime)
            {
                for (int y = 0; y < maxY; y++)
                {
                    for (int x = 0; x < maxX; x++)
                    {
                        Cell cell = Grid1[x, y];

                        if (cell.State == Cell.enumState.FLOOR)
                            cell.NextState = cell.State;

                        else
                        {
                            //count the neighbours
                            int neigh = 0;

                            int deltaY = -1;
                            while (deltaY < 2)
                            {
                                int deltaX = -1;
                                while (deltaX < 2)
                                {
                                    if (!(deltaX == 0 && deltaY == 0))
                                    {
                                        int newX = x + deltaX;
                                        int newY = y + deltaY;

                                        if (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY)
                                        {
                                            if (Grid1[newX, newY].State == Cell.enumState.FULL)
                                                neigh++;
                                        }
                                    }

                                    deltaX++;
                                }
                                deltaY++;
                            }
                            if (cell.State == Cell.enumState.FREE && neigh == 0)
                                cell.NextState = Cell.enumState.FULL;

                            else if (cell.State == Cell.enumState.FULL && neigh >= 4)
                                cell.NextState = Cell.enumState.FREE;
                        }
                    }
                }

                lasttime = occupied;
                occupied = 0;

                foreach (var c in Grid1)
                    occupied += c.Next();
            }
            //  - Draw it!
            Draw(Grid1, maxX, maxY);

            Console.WriteLine(occupied);

            Console.WriteLine("\n------------------------- Part 2");

            Grid1 = new Cell[maxX, maxY];

            for (int y = 0; y < maxY; y++)
            {
                string line = input[y];
                for (int x = 0; x < maxX; x++)
                {
                    Grid1[x, y] = new Cell(line[x], x, y);
                }
            }

            lasttime = -10;
            occupied = 0;

            while (occupied != lasttime)
            {
                for (int y = 0; y < maxY; y++)
                {
                    for (int x = 0; x < maxX; x++)
                    {
                        Cell cell = Grid1[x, y];

                        if (cell.State == Cell.enumState.FLOOR)
                            cell.NextState = cell.State;

                        else
                        {
                            //count the neighbours
                            int neigh = 0;

                            int deltaY = -1;
                            while (deltaY < 2)
                            {
                                int deltaX = -1;
                                while (deltaX < 2)
                                {
                                    if (!(deltaX == 0 && deltaY == 0))
                                    {
                                        int newX = x + deltaX;
                                        int newY = y + deltaY;

                                        while (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY && Grid1[newX, newY].State == Cell.enumState.FLOOR)
                                        {
                                            newX = newX + deltaX;
                                            newY = newY + deltaY;
                                        }
                                        if (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY && Grid1[newX, newY].State == Cell.enumState.FULL)
                                        {
                                            neigh++;
                                        }
                                    }

                                    deltaX++;
                                }
                                deltaY++;
                            }
                            if (cell.State == Cell.enumState.FREE && neigh == 0)
                                cell.NextState = Cell.enumState.FULL;

                            else if (cell.State == Cell.enumState.FULL && neigh >= 5)
                                cell.NextState = Cell.enumState.FREE;
                        }
                    }
                }

                lasttime = occupied;
                occupied = 0;
                Draw(Grid1, maxX, maxY);
                foreach (var c in Grid1)
                    occupied += c.Next();
            }
            //  - Draw it!
            Draw(Grid1, maxX, maxY);

            Console.WriteLine(occupied);
        }
        static void Draw(Cell[,] cells, int maxX, int maxY)
        {
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Console.Write(cells[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}