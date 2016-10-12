using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.Predictors
{
    class Gselect
    {
        const int INIT_BHT_VAL = 2;

        public static support_Classes.Results run(int BHTSize, int historySize, String filePath)
        {
            support_Classes.Results results = new support_Classes.Results();
            support_Classes.PredictionHistoryTable BHT = new support_Classes.PredictionHistoryTable(BHTSize, INIT_BHT_VAL);
            support_Classes.BranchHistoryReg history = new support_Classes.BranchHistoryReg(historySize, 0);

            int missPredic = 0;
            int totalPredictions = 0;

            //open file make sure to read only one line at a time. becuase the file is toooooooo BBIIIGGG

            string line;
            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    String pc = line.Split(new char[0])[0];
                    String pathResult = line.Split(new char[0])[1];

                    //concat pc and globalHistory and get number 
                    int concat = support_Classes.Operators.concat(Convert.ToInt32(pc, 16), history.getHistory());

                    //look at the PHT entry and get the prediction 
                    bool prediction = BHT.shoudTake(concat);
                    bool actual = pathResult.Equals("T");

                    //update the PHT entry
                    BHT.editEntry(concat, actual);
                    history.pushHistory(Convert.ToInt32(actual));

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
    }
}
