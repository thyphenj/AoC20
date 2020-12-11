using System;
namespace _11_SeatingSystem
{
    public class Cell
    {
        public enumState State { set; get; }
        public enumState NextState { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(char ch, int x, int y)
        {
            if (ch == '.')
                State = enumState.FLOOR;
            else if (ch == 'L')
                State = enumState.FREE;
            else
                State = enumState.FULL;

            NextState = State;

            X = x;
            Y = y;
        }
        public int Next()
        {
            State = NextState;
            return State == enumState.FULL ? 1 : 0;
        }

        public override string ToString()
        {
            switch (State)
            {
                case enumState.FLOOR:
                    return ".";
                case enumState.FREE:
                    return "L";
                case enumState.FULL:
                    return "#";
                default:
                    return " ";
            }
        }
        //------------------------------------------------------------
        public enum enumState
        {
            FLOOR,
            FREE,
            FULL
        }
    }
}
