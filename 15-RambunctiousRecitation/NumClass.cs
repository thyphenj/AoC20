using System;
namespace _15_RambunctiousRecitation
{
    public class NumClass
    {
        public int LastPos { get; set; }
        public int PrevPos { get; set; }

        public NumClass(int pos)
        {
            PrevPos = -1;
            LastPos = pos;
        }
        public void Update(int pos)
        {
            PrevPos = LastPos;
            LastPos = pos;
        }
        public override string ToString()
        {
            return $"{PrevPos} : {LastPos}";
        }
    }
}
