using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.support_Classes
{
    class Operators
    {
        public static long XOR(String a, String b, int bitLenght)
        {
            //from the Gskewed paper

            if (a.Length > bitLenght)
            {
                a = a.Substring(a.Length - bitLenght);
            }
            else
            {
                a = a.PadRight(bitLenght, '0');
            }

            if (b.Length > bitLenght)
            {
                b = b.Substring(b.Length - bitLenght);
            }
            else
            {
                b = b.PadRight(bitLenght, '0');
            }

            Debug.Assert(b.Length == bitLenght && a.Length == bitLenght);


            return Convert.ToInt64(b,2) ^ Convert.ToInt64(a,2);
        }

        public static long concat(String a, String b, int bitLenght) {

            //TODO: broken
            if (a.Length > bitLenght)
            {
                a = a.Substring(bitLenght);
            }


            return 4;
        }

        public static bool NOR(bool a, bool b)
        {
            return a == b;
        }
    }
}
