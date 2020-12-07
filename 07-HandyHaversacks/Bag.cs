using System;
namespace _07_HandyHaversacks
{
    public class Bag
    {
        public string Raw { get; set; }
        public string Adjective { get; set; }
        public string Colour { get; set; }

        public Bag(string str)
        {
            Raw = str;

            string[] word = str.Split(' ');
            Adjective = word[0];
            Colour = word[1];
        }

        public override string ToString()
        {
            return $"{Adjective} {Colour}";
        }
    }
}
