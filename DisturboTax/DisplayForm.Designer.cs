namespace DisturboTax
{
    partial class DisplayForm
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
            this.label14 = new System.Windows.Forms.Label();
            this.tbAGI = new System.Windows.Forms.TextBox();
            this.tbCalcTax = new System.Windows.Forms.TextBox();
            this.tbWithheld = new System.Windows.Forms.TextBox();
            this.tbPenalty = new System.Windows.Forms.TextBox();
            this.tfOwedRefund = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOwedRefund = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(64, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(462, 54);
            this.label14.TabIndex = 27;
            this.label14.Text = "DISTURBO TAX 2.0";
            // 
            // tbAGI
            // 
            this.tbAGI.Location = new System.Drawing.Point(341, 146);
            this.tbAGI.Name = "tbAGI";
            this.tbAGI.Size = new System.Drawing.Size(185, 20);
            this.tbAGI.TabIndex = 28;
            // 
            // tbCalcTax
            // 
            this.tbCalcTax.Location = new System.Drawing.Point(341, 172);
            this.tbCalcTax.Name = "tbCalcTax";
            this.tbCalcTax.Size = new System.Drawing.Size(185, 20);
            this.tbCalcTax.TabIndex = 29;
            // 
            // tbWithheld
            // 
            this.tbWithheld.Location = new System.Drawing.Point(341, 198);
            this.tbWithheld.Name = "tbWithheld";
            this.tbWithheld.Size = new System.Drawing.Size(185, 20);
            this.tbWithheld.TabIndex = 30;
            // 
            // tbPenalty
            // 
            this.tbPenalty.Location = new System.Drawing.Point(341, 224);
            this.tbPenalty.Name = "tbPenalty";
            this.tbPenalty.Size = new System.Drawing.Size(185, 20);
            this.tbPenalty.TabIndex = 31;
            // 
            // tfOwedRefund
            // 
            this.tfOwedRefund.Location = new System.Drawing.Point(341, 250);
            this.tfOwedRefund.Name = "tfOwedRefund";
            this.tfOwedRefund.Size = new System.Drawing.Size(185, 20);
            this.tfOwedRefund.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Adjusted Gross Income:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Amount of Calculated Tax:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Amount of Tax Withheld:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Penalty:";
            // 
            // lblOwedRefund
            // 
            this.lblOwedRefund.AutoSize = true;
            this.lblOwedRefund.Location = new System.Drawing.Point(203, 257);
            this.lblOwedRefund.Name = "lblOwedRefund";
            this.lblOwedRefund.Size = new System.Drawing.Size(59, 13);
            this.lblOwedRefund.TabIndex = 38;
            this.lblOwedRefund.Text = "Tax Owed:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(313, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 44);
            this.button3.TabIndex = 42;
            this.button3.Text = "Clear Fields";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 44);
            this.button2.TabIndex = 41;
            this.button2.Text = "View Records";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 44);
            this.button1.TabIndex = 40;
            this.button1.Text = "New Record";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(201, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 29);
            this.label7.TabIndex = 43;
            this.label7.Text = "label7";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 517);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOwedRefund);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tfOwedRefund);
            this.Controls.Add(this.tbPenalty);
            this.Controls.Add(this.tbWithheld);
            this.Controls.Add(this.tbCalcTax);
            this.Controls.Add(this.tbAGI);
            this.Controls.Add(this.label14);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayForm";
            this.Text = "DistruboTax 2.0";
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAGI;
        private System.Windows.Forms.TextBox tbCalcTax;
        private System.Windows.Forms.TextBox tbWithheld;
        private System.Windows.Forms.TextBox tbPenalty;
        private System.Windows.Forms.TextBox tfOwedRefund;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOwedRefund;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}