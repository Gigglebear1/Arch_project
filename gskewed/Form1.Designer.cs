namespace gskewed
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.tbGlobalHistSize = new System.Windows.Forms.TextBox();
            this.tbBHTEnties = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbTraceFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbMiss = new System.Windows.Forms.TextBox();
            this.TbPercent = new System.Windows.Forms.TextBox();
            this.tbCorrect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entries in BHT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size of gloabal history (bits)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prediction method ";
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Gshare",
            "Gselect ",
            "Gskewed"});
            this.cbMethod.Location = new System.Drawing.Point(401, 139);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(259, 33);
            this.cbMethod.TabIndex = 3;
            // 
            // tbGlobalHistSize
            // 
            this.tbGlobalHistSize.Location = new System.Drawing.Point(401, 88);
            this.tbGlobalHistSize.Name = "tbGlobalHistSize";
            this.tbGlobalHistSize.Size = new System.Drawing.Size(259, 31);
            this.tbGlobalHistSize.TabIndex = 4;
            // 
            // tbBHTEnties
            // 
            this.tbBHTEnties.Location = new System.Drawing.Point(401, 32);
            this.tbBHTEnties.Name = "tbBHTEnties";
            this.tbBHTEnties.Size = new System.Drawing.Size(259, 31);
            this.tbBHTEnties.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(734, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbTraceFileName
            // 
            this.tbTraceFileName.Location = new System.Drawing.Point(401, 198);
            this.tbTraceFileName.Name = "tbTraceFileName";
            this.tbTraceFileName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbTraceFileName.Size = new System.Drawing.Size(448, 31);
            this.tbTraceFileName.TabIndex = 7;
            this.tbTraceFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTraceFileName.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trace File name  ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbMiss
            // 
            this.tbMiss.Location = new System.Drawing.Point(338, 73);
            this.tbMiss.Name = "tbMiss";
            this.tbMiss.ReadOnly = true;
            this.tbMiss.Size = new System.Drawing.Size(222, 31);
            this.tbMiss.TabIndex = 0;
            // 
            // TbPercent
            // 
            this.TbPercent.Location = new System.Drawing.Point(338, 192);
            this.TbPercent.Name = "TbPercent";
            this.TbPercent.ReadOnly = true;
            this.TbPercent.Size = new System.Drawing.Size(222, 31);
            this.TbPercent.TabIndex = 1;
            // 
            // tbCorrect
            // 
            this.tbCorrect.Location = new System.Drawing.Point(338, 136);
            this.tbCorrect.Name = "tbCorrect";
            this.tbCorrect.ReadOnly = true;
            this.tbCorrect.Size = new System.Drawing.Size(222, 31);
            this.tbCorrect.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Prediction Miss";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Perdiction Correct";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Prediction Percent";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbGlobalHistSize);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbMethod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbTraceFileName);
            this.groupBox1.Controls.Add(this.tbBHTEnties);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(43, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 302);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbMiss);
            this.groupBox2.Controls.Add(this.tbCorrect);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TbPercent);
            this.groupBox2.Location = new System.Drawing.Point(929, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 302);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Gskewed";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.TextBox tbGlobalHistSize;
        private System.Windows.Forms.TextBox tbBHTEnties;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTraceFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCorrect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbPercent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMiss;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

