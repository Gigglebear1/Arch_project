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
        public static long XOR(String PC, String gh, int bitLenght)
        {

            if (PC.Length > bitLenght)
            {
                PC = PC.Substring(PC.Length - bitLenght);
            }
            else
            {
                PC = PC.PadRight(bitLenght, '0');
            }

            if (gh.Length > bitLenght)
            {
                gh = gh.Substring(gh.Length - bitLenght);
            }
            else
            {
                gh = gh.PadRight(bitLenght, '0');
            }

            Debug.Assert(gh.Length == bitLenght && PC.Length == bitLenght);


            return Convert.ToInt64(gh,2) ^ Convert.ToInt64(PC,2);
        }

        public static long concat(String pc, String gh, int bitLenght) {

            int bitsFromPC = bitLenght - gh.Length;

            String temp = pc.Substring(pc.Length - bitsFromPC) + gh;

            return Convert.ToInt64(temp,2);
        }

        public static bool NOR(bool a, bool b)
        {
            return a == b;
        }
    }
}
