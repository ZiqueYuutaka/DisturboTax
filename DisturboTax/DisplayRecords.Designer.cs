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
            // DisplayRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 517);
            this.Controls.Add(this.lblOR);
            this.Controls.Add(this.lblSsn);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbOR);
            this.Controls.Add(this.tbSsn);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label14);
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
    }
}