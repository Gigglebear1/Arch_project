using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.Predictors
{
    class GSkew
    {
        //that explains why nothing was returned to UI (-_-)

        public static support_Classes.Results run(int bitsPerTable,int ghSize, String filePath)
        {
            support_Classes.Results results = new support_Classes.Results();

            int numAddrBits = bitsPerTable - ghSize;

            support_Classes.PredictionHistoryTable t0 = new support_Classes.PredictionHistoryTable((int)Math.Pow(2, bitsPerTable));
            support_Classes.PredictionHistoryTable t1 = new support_Classes.PredictionHistoryTable((int)Math.Pow(2, bitsPerTable));
            support_Classes.PredictionHistoryTable t2 = new support_Classes.PredictionHistoryTable((int)Math.Pow(2, bitsPerTable));
            support_Classes.BranchHistoryReg history = new support_Classes.BranchHistoryReg(ghSize, 0);

            int missPredic = 0;
            int totalPredictions = 0;

            //open file make sure to read only one line at PC time. becuase the file is toooooooo BBIIIGGG

            string line;
            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    String pc = Convert.ToString(Convert.ToInt64(line.Split(new char[0])[0], 16), 2);
                    pc = pc.Substring(pc.Length - numAddrBits);
                    String pathResult = line.Split(new char[0])[1];


                    Tuple<long, long, long> hasedIndexes = theHasher(pc + history.getHistory(), (int)Math.Floor((double)bitsPerTable/3));

                    bool predict0 = t0.shoudTake(hasedIndexes.Item1);
                    bool predict1 = t1.shoudTake(hasedIndexes.Item2);
                    bool predict2 = t2.shoudTake(hasedIndexes.Item3);

                    //look at the PHT entry and get the prediction 
                    bool prediction = predict0 & predict1 | predict1 & predict2 | predict0 & predict2;
                    bool actual = pathResult.Equals("T");


                    //update tables IF overal prediction is wrong
                    if (prediction != actual)
                    {
                        t0.editEntry(hasedIndexes.Item1, actual);
                        t1.editEntry(hasedIndexes.Item2, actual);
                        t2.editEntry(hasedIndexes.Item3, actual);
                    }

                    // update miss and totalpredictions
                    if (prediction != actual)
                        missPredic += 1;

                    totalPredictions += 1;
                }
            }

            results.correct = totalPredictions - missPredic;
            results.miss = missPredic;
            results.accuracy = ((double)results.correct / (double)totalPredictions) * 100;

            return results;
        }

        private static  Tuple<long, long, long> theHasher(String v, int n)
        {
            string v1 = v.Substring(v.Length - n);
            string v2 = v.Substring(n, n );
            //string v3 = v.Substring(0, v.Length - 2*n);

            long f0 = xor3(hash(v1), hashInverse(v2), Convert.ToInt64(v2, 2));
            long f1 = xor3(hash(v1), hashInverse(v2), Convert.ToInt64(v1, 2));
            long f2 = xor3(hashInverse(v1), hash(v2), Convert.ToInt64(v2,2));

            Tuple<long, long, long> hashIndex = new Tuple<long, long, long>(f0, f1, f2);

            return hashIndex;
        }

        private static long hash(String v)
        {
            String shift = v.Substring(0, v.Length - 1);
            String xor = (Convert.ToInt32(v[0]) ^ Convert.ToInt32(v[v.Length-1])).ToString();
            return Convert.ToInt64(xor+shift,2);
        }

        private static long hashInverse(String v)
        {
            String shift = v.Substring(1, v.Length-1);
            String xor = (Convert.ToInt32(v[0]) ^ Convert.ToInt32(v[v.Length - 1])).ToString();
            return Convert.ToInt64(shift + xor,2);
        }

        private static long xor3(long v1,long v2,long v3){
            return v1 ^ v2 ^ v3;
        }
    }
}
