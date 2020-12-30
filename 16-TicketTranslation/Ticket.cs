using System.Collections.Generic;

namespace _16_TicketTranslation
{
    public class Ticket
    {
        public List<int> Contents { get; set; }
        public bool Valid { get; set; }

        public Ticket(string str)
        {
            Contents = new List<int>();

            foreach (var s in str.Split(','))
                Contents.Add(int.Parse(s));
        }
        public int Validate(List<Field> fields)
        {
            int sum = 0;
            foreach (var c in Contents)
            {
                foreach (var f in fields)
                    sum += f.Validate(c);
            }
            return sum;
        }
        public override string ToString()
        {
            string str = "";
            foreach (var s in Contents)
                str += $"{s,3}  ";
            return str;
        }
    }
}
