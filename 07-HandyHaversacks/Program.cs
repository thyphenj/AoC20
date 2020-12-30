using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _07_HandyHaversacks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            // ---------------------- Massage ----------------------------
            List<Recipe> recipes = new List<Recipe>();

            foreach (var l in input)
            {
                Recipe rcp = new Recipe(l);
                recipes.Add(rcp);
            }

            Console.WriteLine("07-HandyHaversacks\n------------------- Part 1 -----------------------");

            HashSet<Bag> found = new HashSet<Bag>();

            foreach (var recipe in recipes)
            {
                var bag = recipe.Contents.Keys.Where(a => a.Raw == "shiny gold").FirstOrDefault();
                if (bag != null)
                {
                    found.Add(recipe.ThisBag);
                }
            }

            int count = -1;
            while (found.Count != count)
            {
                count = found.Count;
                HashSet<Bag> f2 = new HashSet<Bag>();
                foreach (var recipe in recipes)
                {
                    foreach (var r in found)
                    {
                        var bag = recipe.Contents.Keys.Where(a => a.Raw == r.Raw).FirstOrDefault();
                        if (bag != null)
                        {
                            f2.Add(recipe.ThisBag);
                        }
                    }
                }
                foreach (var f in f2)
                    found.Add(f);
            }
            Console.WriteLine(found.Count);

            Console.WriteLine("\n------------------- Part 2 -----------------------");

            Recipe root = recipes.Where(a => a.ThisBag.Raw == "shiny gold").FirstOrDefault();
            Console.WriteLine($"{root.Raw}\n---------");

            //count = 0;
            int s0 = 0;
            foreach (var lev0 in root.Contents)
            {
                Console.WriteLine($"0  {lev0.Value} {lev0.Key.Raw}");
                int s1 = 0;
                foreach (var lev1 in recipes.Where(b => b.ThisBag.Raw == lev0.Key.Raw).FirstOrDefault().Contents)
                {
                    Console.WriteLine($"1      {lev1.Value} {lev1.Key.Raw}");
                    int s2 = 0;
                    foreach (var lev2 in recipes.Where(z => z.ThisBag.Raw == lev1.Key.Raw).FirstOrDefault().Contents)
                    {
                        Console.WriteLine($"2          {lev2.Value} {lev2.Key.Raw}");
                        int s3 = 0;
                        foreach (var lev3 in recipes.Where(z => z.ThisBag.Raw == lev2.Key.Raw).FirstOrDefault().Contents)
                        {
                            Console.WriteLine($"3              {lev3.Value} {lev3.Key.Raw}");
                            int s4 = 0;
                            foreach (var lev4 in recipes.Where(z => z.ThisBag.Raw == lev3.Key.Raw).FirstOrDefault().Contents)
                            {
                                Console.WriteLine($"4                  {lev4.Value} {lev4.Key.Raw}");
                                int s5 = 0;
                                foreach (var lev5 in recipes.Where(z => z.ThisBag.Raw == lev4.Key.Raw).FirstOrDefault().Contents)
                                {
                                    Console.WriteLine($"5                      {lev5.Value} {lev5.Key.Raw}");
                                    int s6 = 0;
                                    foreach (var lev6 in recipes.Where(z => z.ThisBag.Raw == lev5.Key.Raw).FirstOrDefault().Contents)
                                    {
                                        Console.WriteLine($"6                          {lev6.Value} {lev6.Key.Raw}");
                                        int s7 = 0;
                                        foreach (var lev7 in recipes.Where(a => a.ThisBag.Raw == lev6.Key.Raw).FirstOrDefault().Contents)
                                        {
                                            Console.WriteLine($"7                             {lev7.Value} {lev7.Key.Raw}");
                                            s7 += lev7.Value;
                                        }
                                        s6 += lev6.Value * s7;
                                    }
                                    s5 += lev5.Value * s6;
                                }
                                s4 += lev4.Value * s5;
                            }
                            s3 += lev3.Value * s4;
                        }
                        s2 += lev2.Value * s3;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
