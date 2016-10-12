using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.support_Classes
{
    class BranchHistoryReg
    {
        private Queue<int> history;
        private int limit;

        public BranchHistoryReg(int size, int initvalue = 0)
        {
            limit = size;
            history = new Queue<int>();
            for (int i = 0; i < size; ++i)
            {
                history.Enqueue(initvalue);
            }
        }

        public void pushHistory(int hist){
            if (history.Count == limit)
                history.Dequeue();
            history.Enqueue(hist);
        }

        public int getHistory(){
            String hist = "";
            foreach (int i in this.history)
            {
                hist += i.ToString();
            }

            

            return Convert.ToInt32(hist,2);
        }

    }
}
