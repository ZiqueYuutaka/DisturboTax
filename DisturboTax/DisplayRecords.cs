using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisturboTax
{
    public partial class DisplayRecords : Form
    {
        taxpayerFinal[] records;
        private int index = 0;

        public DisplayRecords()
        {
            InitializeComponent();
        }

        private void DisplayRecords_Load(object sender, EventArgs e)
        {
            records = DisplayForm.taxpArray;

            //Sort array

            //Display first record
            displayRecord(records[index]);
            enableDisableButton(btnPrevious, index, 0);
            if(records[1].name.Equals(""))
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private void displayRecord(taxpayerFinal taxpayer)
        {
            tbName.Text = taxpayer.name;
            tbSsn.Text = taxpayer.ssn;
            decimal temp;
            if(taxpayer.owedOrRefunded < 0)
            {
                temp = (-1m * taxpayer.owedOrRefunded);
                lblOR.Text = "Tax Owed:";
                tbOR.Text = temp.ToString("c");

            }else
            {
                lblOR.Text = "Refund";
                tbOR.Text = taxpayer.owedOrRefunded.ToString("c");
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index--;
            enableDisableButton(btnPrevious, index, 0);
            enableDisableButton(btnNext, index, 9);
            displayRecord(records[index]);
        }

        private void enableDisableButton(Button btn, int index, int extrema)
        {

            if(index == extrema)
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            enableDisableButton(btnPrevious, index, 0);
            if (index == records.Length - 1 || records[index + 1].name.Equals(""))
            {
                enableDisableButton(btnNext, 9, 9);
            }
            displayRecord(records[index]);
        }

        private void btnClearRec_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult clearRecord;
            clearRecord = MessageBox.Show("You are about to delete a record.  Continue?", "Delete Record", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(clearRecord == System.Windows.Forms.DialogResult.Yes)
            {
                reorderArray();
                DisplayForm.taxpArray = records;
                DisplayForm.endIndex--;
                if(index < 0)
                    index--;

                enableDisableButton(btnNext, index, DisplayForm.endIndex);
                enableDisableButton(btnPrevious, index, 0);
                tbName.Text = records[index].name;
                tbSsn.Text = records[index].ssn;
                if(records[index].owedOrRefunded == 0.00m)
                {
                    tbOR.Text = "";
                }
                else
                {
                    tbOR.Text = records[index].owedOrRefunded.ToString("c");
                }
            }
            if (DisplayForm.endIndex == 0)
            {
                btnClearRec.Enabled = false;
            }
            else
            {
                btnClearRec.Enabled = true;

            }
            
        }

        private void reorderArray()
        {
            for(int i = index; i < DisplayForm.endIndex; i++)
            {
                records[i] = records[index + 1];
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
