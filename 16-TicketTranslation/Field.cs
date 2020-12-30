using System;
namespace _16_TicketTranslation
{

    // train: 45-831 or 842-965
    public class Field
    {
        public string Name { get; set; }
        public Rnge RangeA { get; set; }
        public Rnge RangeB { get; set; }

        public Field(string str)
        {
            string[] work = str.Split(": ");
            Name = work[0];

            work = work[1].Split(" or ");

            string[] w2 = work[0].Split("-");
            RangeA = new Rnge(int.Parse(w2[0]), int.Parse(w2[1]));

            w2 = work[1].Split("-");
            RangeB = new Rnge(int.Parse(w2[0]), int.Parse(w2[1]));
        }

        public int Validate(int val)
        {
            if (RangeA.Incl(val) || RangeB.Incl(val))
                return 0;

            return val;
        }

        public override string ToString()
        {
            return $"{Name,20} [{RangeA.Lo,3}-{RangeA.Hi,3}] [{RangeB.Hi,3}-{RangeB.Hi,3}]";
        }
    }
    public class Rnge
    {
        public int Lo { get; set; }
        public int Hi { get; set; }

        public Rnge(int lo, int hi)
        {
            Lo = lo;
            Hi = hi;
        }
        public bool Incl(int val)
        {
            return (val >= Lo && val <= Hi);
        }
        public override string ToString()
        {
            return $"[{Lo}-{Hi}]";
        }
    }
}
