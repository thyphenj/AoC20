using System;
namespace _08_HandheldHalting
{
    public class Instruction
    {
        public string Raw { get; set; }
        public string Opcode { get; set; }
        public int Argument { get; set; }
        public int Visited { set; get; }
        static private int Accumulator { get; set; }

        public Instruction(string str)
        {
            string[] wrk = str.Split(' ');
            Opcode = wrk[0];
            Argument = int.Parse(wrk[1]);
            Raw = str;

            Visited = 0;
            Accumulator = 0;
        }

        public int Perform()
        {
            Visited++;
            switch (Opcode)
            {
                case "acc":
                    Accumulator += Argument;
                    return 1;

                case "nop":
                    return 1;

                case "jmp":
                    return Argument;

                default:
                    break;
            }
            return -9999;
        }

        public override string ToString()
        {
            return $"{Opcode} {Argument,4}    {Accumulator,6}";
        }
    }
}
