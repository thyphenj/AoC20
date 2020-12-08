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
            //Bag root = new Bag("four or five");

            foreach (var l in input)
            {
                Recipe rcp = new Recipe(l);
                recipes.Add(rcp);
                if (rcp.ThisBag.Raw == "shiny gold")
                {
                    //root = rcp.ThisBag;
                }
            }

            Console.WriteLine("------------------- Part 1 -----------------------");

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

            Console.WriteLine("------------------- Part 2 -----------------------");

            found = new HashSet<Bag>();

            Recipe root = recipes.Where(a => a.ThisBag.Raw == "shiny gold").FirstOrDefault();

            foreach (var x in root.Contents.Keys)
                Console.WriteLine(x.Raw);

            Console.WriteLine(found.Count);

        }
    }
}
