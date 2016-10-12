using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.support_Classes
{
    class Operators
    {
        public static int XOR(int a, int b){
            return a ^ b;
        }

        public static int concat(int a, int b) {
            return Convert.ToInt32(Convert.ToString(a,2) + Convert.ToString(b,2),2);
        }

        public static bool NOR(bool a, bool b)
        {
            return a == b;
        }
    }
}
