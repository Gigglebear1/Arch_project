using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.support_Classes
{
    class Operators
    {
        public static long XOR(long a, long b){
            return a ^ b;
        }

        public static long concat(long a, long b) {
            return Convert.ToInt64(Convert.ToString(a,2) + Convert.ToString(b,2),2);
        }

        public static bool NOR(bool a, bool b)
        {
            return a == b;
        }
    }
}
