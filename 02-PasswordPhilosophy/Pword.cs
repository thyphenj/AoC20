using System;
using System.Collections.Generic;
using System.Text;

namespace _02_PasswordPhilosophy
{
    class Pword
    {
        public int Lo { get; set; }
        public int Hi { get; set; }
        public char Chr { get; set; }
        public string Password { get; set; }

        public Pword (string str)
        {
            var a = str.Split(": ");
            Password = a[1];

            var b = a[0].Split(' ');
            Chr = b[1][0];

            var c = b[0].Split('-');
            Lo = int.Parse(c[0]);
            Hi = int.Parse(c[1]);
        }

        public bool ValidCount()
        {
            int cnt = 0;
            foreach ( var c in Password )
            {
                if (c == Chr) cnt++;
            }
            if (cnt >= Lo && cnt <= Hi )
                return true;
            else
                return false;
        }

        public bool ValidPosition()
        {
            var ch1 = Password[Lo - 1];
            var ch2 = Password[Hi - 1];
            if (ch1 == Chr || ch2 == Chr)
                if (ch1 != ch2)
                    return true;

            return false;
        }
        public override string ToString()
        {
            return $"{Lo,2}-{Hi,2} [{Chr}] {Password}";
        }
    }
}
