using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gskewed.support_Classes
{
    class behaviorHistoryTable
    {

        private int[] table;
        private const int COUNTER_MAX = 4;
        private const int COUNTER_MIN = 0;
        private const int ShouldTakeValue = 2;
        private int BHTSize;
        private int p;

        public behaviorHistoryTable(int size, int initValue = 2)
        {
            BHTSize = size;
            table = new int[size];
            for (int i = 0; i < size; ++i)
                table[i] = initValue;
        }

        public void editEntry(int entry, bool taken){
            if (taken && table[entry % BHTSize] != COUNTER_MAX)
                table[entry % BHTSize] += 1;
            else if (!taken && table[entry % BHTSize] != COUNTER_MIN)
                table[entry % BHTSize] -= 1;
        }

        public bool shoudTake(int entry){
            return table[entry % BHTSize] >= ShouldTakeValue;
        }

        public int size(){
            return table.Length;
        }


    }
}
