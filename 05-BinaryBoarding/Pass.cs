using System;
namespace _05_BinaryBoarding
{
    public class Pass
    {
        public string Raw { set; get; }
        public int Seat { get; set; }
        public int Row { get; set; }
        public int ID { get; set; }

        public Pass(string str)
        {
            Raw = str;
            ID = Bin2Dec(Raw);
            Row = Bin2Dec(Raw.Substring(0, 7));
            Seat = Bin2Dec(Raw.Substring(7, 3));
        }
        static private int Bin2Dec(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sum = sum * 2 + (str[i] == 'F' || str[i] == 'L' ? 0 : 1);
            }
            return sum;
        }
    }
}
