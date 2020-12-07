using System;
using System.Collections.Generic;

namespace _07_HandyHaversacks
{
    public class Recipe
    {
        public string Raw { get; set; }

        public Bag ThisBag { get; set; }
        public Dictionary<Bag, int> Contents { get; set; }

        public Recipe(string str)
        {
            Raw = str;
            Contents = new Dictionary<Bag, int>();

            string[] para = str.Replace(".", "").Replace(" bags", "").Replace(" bag", "").Split(" contain ");

            ThisBag = new Bag(para[0]);

            if (para[1] != "no other")
            {
                para = para[1].Split(", ");
                foreach (var p in para)
                {
                    int spaceAt = p.IndexOf(' ');

                    int n = Convert.ToInt16(p.Substring(0, spaceAt));
                    Bag bag = new Bag(p.Substring(spaceAt + 1));

                    Contents.Add(bag, n);
                }
            }
        }
        public override string ToString()
        {
            return $"{ThisBag} {Contents.Count}";
        }
    }
}
