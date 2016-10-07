namespace DisturboTax
{
    partial class DisplayRecords
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
            this.lblOR = new System.Windows.Forms.Label();
            this.lblSsn = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbOR = new System.Windows.Forms.TextBox();
            this.tbSsn = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnClearRec = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(64, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(462, 54);
            this.label14.TabIndex = 28;
            this.label14.Text = "DISTURBO TAX 2.0";
            // 
            // lblOR
            // 
            this.lblOR.AutoSize = true;
            this.lblOR.Location = new System.Drawing.Point(240, 255);
            this.lblOR.Name = "lblOR";
            this.lblOR.Size = new System.Drawing.Size(85, 13);
            this.lblOR.TabIndex = 46;
            this.lblOR.Text = "Refund or Owed";
            // 
            // lblSsn
            // 
            this.lblSsn.AutoSize = true;
            this.lblSsn.Location = new System.Drawing.Point(240, 229);
            this.lblSsn.Name = "lblSsn";
            this.lblSsn.Size = new System.Drawing.Size(120, 13);
            this.lblSsn.TabIndex = 45;
            this.lblSsn.Text = "Social Security Number:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(240, 202);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 44;
            this.lblName.Text = "Full Name:";
            // 
            // tbOR
            // 
            this.tbOR.Location = new System.Drawing.Point(378, 248);
            this.tbOR.Name = "tbOR";
            this.tbOR.Size = new System.Drawing.Size(185, 20);
            this.tbOR.TabIndex = 41;
            // 
            // tbSsn
            // 
            this.tbSsn.Location = new System.Drawing.Point(378, 222);
            this.tbSsn.Name = "tbSsn";
            this.tbSsn.Size = new System.Drawing.Size(185, 20);
            this.tbSsn.TabIndex = 40;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(378, 196);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(185, 20);
            this.tbName.TabIndex = 39;
            // 
            // btnClearRec
            // 
            this.btnClearRec.Location = new System.Drawing.Point(313, 419);
            this.btnClearRec.Name = "btnClearRec";
            this.btnClearRec.Size = new System.Drawing.Size(178, 44);
            this.btnClearRec.TabIndex = 48;
            this.btnClearRec.Text = "Clear Records";
            this.btnClearRec.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(549, 419);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(178, 44);
            this.btnNext.TabIndex = 49;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(73, 419);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(178, 44);
            this.btnPrevious.TabIndex = 47;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // DisplayRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 517);
            this.Controls.Add(this.btnClearRec);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblOR);
            this.Controls.Add(this.lblSsn);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbOR);
            this.Controls.Add(this.tbSsn);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label14);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayRecords";
            this.Text = "DisplayRecords";
            this.Load += new System.EventHandler(this.DisplayRecords_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblOR;
        private System.Windows.Forms.Label lblSsn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbOR;
        private System.Windows.Forms.TextBox tbSsn;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnClearRec;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
    }
}