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
            records = DisplayForm.getArray();

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
    }
}
