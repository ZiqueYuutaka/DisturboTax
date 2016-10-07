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

        public DisplayRecords()
        {
            InitializeComponent();
        }

        private void DisplayRecords_Load(object sender, EventArgs e)
        {
            records = DisplayForm.getArray();

            //Sort array

            //Display first record
            displayRecord(records[0]);
        }

        private void displayRecord(taxpayerFinal taxpayer)
        {
            tbName.Text = taxpayer.name;
            tbSsn.Text = taxpayer.ssn;
            decimal temp;
            if(taxpayer.owedOrRefunded < 0)
            {
                temp = taxpayer.owedOrRefunded * -1m;
                lblOR.Text = "Tax Owed:";
                tbOR.Text = taxpayer.owedOrRefunded.ToString("c");

            }else
            {
                lblOR.Text = "Refund";
                tbOR.Text = taxpayer.owedOrRefunded.ToString("c");
            }

        }
    }
}
