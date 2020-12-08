using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _08_HandheldHalting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            // ---------------------- Massage ----------------------------
            Console.WriteLine("------------------- Part 1 -----------------------");

            List<Instruction> instructions = new List<Instruction>();
            foreach (var ins in input)
                instructions.Add(new Instruction(ins));

            int sp = 0;
            int offset = instructions[sp].Perform();
            while (instructions[sp].Visited < 2)
            {
                sp += offset;
                offset = instructions[sp].Perform();
            }
            Console.WriteLine($"[{sp,4}]  {instructions[sp]} {instructions[sp].Visited}");

            Console.WriteLine("------------------- Part 2 -----------------------");

            for (int i = 0; i < instructions.Count; i++)
            {
                instructions = new List<Instruction>();
                foreach (var ins in input)
                    instructions.Add(new Instruction(ins));

                if (instructions[i].Opcode == "jmp" || instructions[i].Opcode == "nop")
                {
                    instructions[i].Opcode = instructions[i].Opcode == "jmp" ? "nop" : "jmp";
                    {
                        sp = 0;
                        offset = instructions[sp].Perform();
                        while (sp >= 0 && sp < instructions.Count && instructions[sp].Visited < 2)
                        {
                            sp += offset;
                            if (sp >= 0 && sp < instructions.Count)
                                offset = instructions[sp].Perform();
                        }
                        if (sp >= instructions.Count)
                            Console.WriteLine($"[{sp - 1,4}]  {instructions[sp - 1]} {instructions[sp - 1].Visited}");
                    }
                    instructions[i].Opcode = instructions[i].Opcode == "jmp" ? "nop" : "jmp";
                }
            }
        }
    }
}
