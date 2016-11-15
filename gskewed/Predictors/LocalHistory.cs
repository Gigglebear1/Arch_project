using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.Predictors
{
    class LocalHistory
    {
        const int INIT_BHT_VAL = 2;

        public static support_Classes.Results run(int BHTSize, int historySize, String filePath)
        {
            support_Classes.Results results = new support_Classes.Results();
            support_Classes.PredictionHistoryTable BHT = new support_Classes.PredictionHistoryTable(BHTSize, INIT_BHT_VAL);

            int logOfEneries = (int)Math.Log(BHTSize, 2);
            int missPredic = 0;
            int totalPredictions = 0;

            //open file make sure to read only one line at PC time. becuase the file is toooooooo BBIIIGGG

            string line;
            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    String PC = Convert.ToString(Convert.ToInt64(line.Split(new char[0])[0], 16), 2);
                    String pathResult = line.Split(new char[0])[1];

                    if (PC.Length > logOfEneries)
                    {
                        PC = PC.Substring(PC.Length - logOfEneries);
                    }
                    else
                    {
                        PC = PC.PadRight(logOfEneries, '0');
                    }

                    //look at the PHT entry and get the prediction 
                    bool prediction = BHT.shoudTake(Convert.ToInt64(PC,2));
                    bool actual = pathResult.Equals("T");

                    BHT.editEntry(Convert.ToInt64(PC, 2), actual);

                    // update miss and totalpredictions
                    if (prediction != actual)
                        missPredic += 1;

                    //update the PHT entry
                    totalPredictions += 1;
                }
            }

            results.correct = totalPredictions - missPredic;
            results.miss = missPredic;
            results.accuracy = ((double)results.correct / (double)totalPredictions) * 100;

            return results;
        }
    }
}
