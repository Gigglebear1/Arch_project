using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gskewed.support_Classes
{
    class BiasBitTable
    {
        private int tagSize;
        private long numEntries;
        Entry[] BTB;

        public BiasBitTable(int numEntries_in)
        {
            tagSize = (int)Math.Log(numEntries_in, 2);
            numEntries = numEntries_in;
            BTB = new Entry[numEntries_in];
            for (int i = 0; i < numEntries; ++i)
            {
                //cant have PC negative tag so it is safe to declare it with that 
                BTB[i] = new Entry(-1,true);
            }
        }


        /// <summary>
        /// return -1 if not there or invalid or return the bit
        /// </summary>
        /// <param name="bitAddr"></param>
        /// <returns></returns>
        public int getBiasBit(String bitAddr)
        {
            Int64 tag = Convert.ToInt32(bitAddr.Substring(0,tagSize), 2);
            Int64 index = Convert.ToInt64(bitAddr.Substring(tagSize),2);

           
            if (BTB[index].tag == tag)
            {
                return Convert.ToInt32(BTB[index].bit);
            }

            return -1;
        }

        /// <summary>
        /// takes in PC bitAddr String 
        /// </summary>
        /// <param name="bitAddr"></param>
        /// <param name="bit"></param>
        public void setBiasBit(String bitAddr, bool bit)
        {
            int tag = Convert.ToInt32(bitAddr.Substring(0, tagSize), 2);
            Int64 index = Convert.ToInt64(bitAddr.Substring(tagSize), 2);

            BTB[index].tag = tag;
            BTB[index].bit = bit;
        }
        
    }

    class Entry{
        public int tag {get; set;}
        public bool bit{get; set;}
        public Entry(int tag_in, bool bit_in)
        {
            tag = tag_in;
            bit = bit_in;
        }

    }
}
