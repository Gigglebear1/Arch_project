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
            tbTraceFileName.Text = @"Z:\Desktop\Fall 2016\arch\term project\parsed\art-100M_parsed.trace";

            cbMethod.SelectedIndex = 1;
            tbBHTEnties.Text = "16";
            tbGlobalHistSize.Text = "16";
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

        private async void button1_Click(object sender, EventArgs e)
        {
            //big ole switch to statment to select the stuff 
            //pass in (PHT size, globalHistory size, file path)
            //fire off on new thread 

            Application.UseWaitCursor = true;

            int numofPHTEntires = Convert.ToInt32(Math.Pow(2,Convert.ToInt32(tbBHTEnties.Text)));

            if (cbMethod.SelectedIndex == 1 || cbMethod.SelectedIndex == 0)
            {
                if (Convert.ToInt32(tbBHTEnties.Text) < Convert.ToInt32(tbGlobalHistSize.Text))
                {
                    MessageBox.Show("Global history bits must be less that PHT bits");
                    Application.UseWaitCursor = false;
                    return;
                }
            }
          

            support_Classes.Results res = new support_Classes.Results();

            switch (cbMethod.SelectedIndex)
            {
                case 0:
                    res = await Task.Run(() => Predictors.GShare.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text));
                    //res = Predictors.GShare.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text);
                    break;
                case 1:
                    res = await Task.Run(() => Predictors.Gselect.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text));
                    break;
                case 2:
                    res = await Task.Run(() => Predictors.GSkew.run(Convert.ToInt32(tbBHTEnties.Text),Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text));
                    break;
                case 3:
                    res = await Task.Run(() => Predictors.LocalHistory.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), 1, tbTraceFileName.Text));
                    //res = Predictors.AgreePredictor.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), tbTraceFileName.Text);
                    break;
                case 4:
                    res = await Task.Run(() => Predictors.LocalHistory.run(numofPHTEntires, Convert.ToInt32(tbGlobalHistSize.Text), 2, tbTraceFileName.Text));
                    break;
                case 5:
                    res = await Task.Run(() => Predictors.AlwaysTake.run(tbTraceFileName.Text));
                    break;
                case 6:
                    res = await Task.Run(() => Predictors.AlwaysDontTake.run(tbTraceFileName.Text));
                    break;
            }
           

            tbMiss.Text = Convert.ToString(res.miss);
            tbCorrect.Text = Convert.ToString(res.correct);
            TbPercent.Text = Convert.ToString(res.accuracy) + "%";
            Application.UseWaitCursor = false;
        }


        private void tbBHTEnties_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //private void cbMethod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbMethod.SelectedIndex == 2)
        //    {
        //        tbBHTEnties.Enabled = false;
        //        double ghSize = String.IsNullOrEmpty(tbGlobalHistSize.Text) ? 0.0 : (double)Convert.ToInt32(tbGlobalHistSize.Text);
        //        tbBHTEnties.Text = Math.Ceiling((ghSize+24) / 3).ToString();
        //    }
        //    else
        //    {
        //        tbBHTEnties.Enabled = true;
        //    }
        //}

        //private void tbGlobalHistSize_TextChanged(object sender, EventArgs e)
        //{
        //    if (cbMethod.SelectedIndex == 2)
        //    {
        //        double ghSize = String.IsNullOrEmpty(tbGlobalHistSize.Text) ? 0.0 : (double)Convert.ToInt32(tbGlobalHistSize.Text);
        //        tbBHTEnties.Text = Math.Ceiling((ghSize + 24) / 3).ToString();
        //    }

        //}

    }
}
