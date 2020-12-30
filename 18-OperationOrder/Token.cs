namespace _18_OperationOrder
{

    public class Token
    {
        public long Value { get; set; }
        public char Text { get; set; }
        public int BracketDepth { get; set; }

        private static int Depth;
        private static int Max;

        public Token()
        {
            Depth = 0;
            Max = 0;
        }
        public Token(long s, int d)
        {
            Value = s;
            BracketDepth = d;
        }
        public Token(char ch)
        {
            Text = ch;
            if (ch >= '0' && ch <= '9')
                Value = ch - '0';
            else
                Value = 0;
            if (ch == '(')
                Depth++;
            if (ch == ')')
                Depth--;
            if (Depth > Max)
                Max = Depth;
            BracketDepth = Depth;
        }

        public static int MaxDepth()
        {
            return Max;
        }
        public override string ToString()
        {
            if (Text == '\0')
            {
                return $"{Value} {BracketDepth}";
            }
            else
            {
                return $"{Text} {BracketDepth}";
            }
        }
    }
}