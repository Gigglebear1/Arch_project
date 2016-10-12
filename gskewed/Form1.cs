using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gskewed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            tbTraceFileName.Text = @"Z:\Desktop\Fall 2016\arch\term project\parseing\gcc-50M_parsed_sper_small.trace";

            cbMethod.SelectedIndex = 1;
            tbBHTEnties.Text = "2";
            tbGlobalHistSize.Text = "4";
            tbBitsInPC.Text = "24";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open trace File";
            theDialog.Filter = "Trace files|*.trace";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                tbTraceFileName.Text = theDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //big ole switch to statment to select the stuff 
            //pass in (PHT size, globalHistory size, file path)
            //fire off on new thread 

            support_Classes.Results res = new support_Classes.Results();

            switch (cbMethod.SelectedIndex)
            {
                case 0:
                    res = Predictors.GShare.run(Convert.ToInt32(tbBHTEnties.Text), Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text);
                    break;
                case 1:
                    res = Predictors.Gselect.run(Convert.ToInt32(tbBHTEnties.Text), Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text);
                    break;
                case 2:
                    break;
                case 3:
                    res = Predictors.AgreePredictor.run(Convert.ToInt32(tbBHTEnties.Text), Convert.ToInt32(tbGlobalHistSize.Text), Convert.ToInt32(tbBitsInPC.Text), Convert.ToInt32(tbBiasTagSize.Text), tbTraceFileName.Text);
                    break;
                case 4:
                    res = Predictors.TwoLevelPredictorLocalHistory.run(Convert.ToInt32(tbBHTEnties.Text), Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text);
                    break;
            }
           

            tbMiss.Text = Convert.ToString(res.miss);
            tbCorrect.Text = Convert.ToString(res.correct);
            TbPercent.Text = Convert.ToString(res.accuracy) + "%";

        }

        private void cbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMethod.SelectedIndex == 3)
            {
                //show extra options
                lbNumBitsInPC.Show();
                lbBiasTagSize.Show();
                lbNote.Show();
                tbBiasTagSize.Show();
                tbBitsInPC.Show();
            }
            else
            {
                //hide them
                lbNumBitsInPC.Hide();
                lbBiasTagSize.Hide();
                lbNote.Hide();
                tbBiasTagSize.Hide();
                tbBitsInPC.Hide();

            }
        }
    }
}
