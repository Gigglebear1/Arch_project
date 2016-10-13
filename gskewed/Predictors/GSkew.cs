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

        public static support_Classes.Results run(String filePath)
        {
            support_Classes.Results results = new support_Classes.Results();

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

                    //look at the PHT entry and get the prediction 
                    bool prediction = true;
                    bool actual = pathResult.Equals("T");

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
