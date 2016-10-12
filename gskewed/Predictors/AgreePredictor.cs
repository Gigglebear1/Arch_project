using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gskewed.Predictors
{
    class AgreePredictor
    {

        //using first time selection mechanism 

        const int INIT_BHT_VAL = 2;

        public static support_Classes.Results run(int BHTSize, int historySize,int BTBBitsInPc, int BTBTagSize, String filePath)
        {
            support_Classes.Results results = new support_Classes.Results();
            support_Classes.PredictionHistoryTable PHT = new support_Classes.PredictionHistoryTable(BHTSize, INIT_BHT_VAL);
            support_Classes.BranchHistoryReg globalHistory = new support_Classes.BranchHistoryReg(historySize, 0);
            support_Classes.BiasBitTable BTB = new support_Classes.BiasBitTable(BTBBitsInPc, BTBTagSize);

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
                    int concat = support_Classes.Operators.XOR(Convert.ToInt32(pc, 16), globalHistory.getHistory());

                    //look at the PHT entry and get the prediction 
                    bool predictionfromPHT = PHT.shoudTake(concat);
                    bool actual = pathResult.Equals("T");

                    String pcBinaryStr = Convert.ToString(Convert.ToInt64(pc, 16), 2).PadLeft(24, '0');
                    bool overAllPrediction = false;
                    if (BTB.getBiasBit(pcBinaryStr) != -1)
                    {
                        //means we have a bias bit and it is for the proper tag/address
                        bool biasBit = Convert.ToBoolean(BTB.getBiasBit(pcBinaryStr));
                        overAllPrediction = support_Classes.Operators.NOR(biasBit, predictionfromPHT);
                        
                    }
                    else
                    {
                        //we dont have a bias bit right now for this tag/address
                        //we wil set it to what the first actual direction is and predict with out the bias bit
                        overAllPrediction = predictionfromPHT;

                        //update the bias bit to the actual 
                        BTB.setBiasBit(pcBinaryStr, actual);

                    }



                    //update the PHT entry and globalHistory
                    PHT.editEntry(concat, actual);
                    globalHistory.pushHistory(Convert.ToInt32(actual));

                    // update miss and totalpredictions
                    if (overAllPrediction != actual)
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
