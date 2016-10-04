﻿using System;
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

    public partial class DisplayForm : Form
    {
        
        private const int SIZE = 10;
        static taxpayer[] taxpArray = new taxpayer[SIZE];
        static int tracker = 0;
        taxpayer newTaxp;

        public DisplayForm()
        {
            InitializeComponent();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            newTaxp = InputForm.getTaxpayerInfo();
            label7.Text = "Calculated tax information for:\n" + newTaxp.name;

            //Calculate each deduction at 1000
            if(newTaxp.exemptions != 0)
            {
                newTaxp.calculatedItems.deductCalc = (decimal)(newTaxp.exemptions * 1000.00);
                Console.WriteLine(newTaxp.calculatedItems.deductCalc);
            }

            //Calculate Real Estate Tax
            if(newTaxp.taxItems.realEstate != 0)
            {
                newTaxp.calculatedItems.reCalc = percentageCalc(newTaxp.taxItems.realEstate, 0.25);
                Console.WriteLine(newTaxp.calculatedItems.reCalc);
            }

            //Calculate Excise Tax
            if(newTaxp.taxItems.excise != 0)
            {
                newTaxp.calculatedItems.exciseCalc = percentageCalc(newTaxp.taxItems.excise, 0.25);
                Console.WriteLine(newTaxp.calculatedItems.exciseCalc);
            }
                
            //Deduction for medical
            if(newTaxp.taxItems.medicalExpense != 0)
            {
                newTaxp.calculatedItems.medCalc = percentageCalc(newTaxp.taxItems.medicalExpense, 0.08);
                Console.WriteLine(newTaxp.calculatedItems.medCalc);
            }

            //Add 15% for capital gains to gross(if present)
            if(newTaxp.taxItems.gains != 0)
            {
                newTaxp.calculatedItems.gainsCalc = percentageCalc(newTaxp.taxItems.gains, 0.15);
                Console.WriteLine(newTaxp.calculatedItems.gainsCalc);
            }

            //Sub 15% for capital loss to gross(if present)
            if (newTaxp.taxItems.loss != 0)
            {
                newTaxp.calculatedItems.lossCalc = percentageCalc(newTaxp.taxItems.loss, 0.15);
                Console.WriteLine(newTaxp.calculatedItems.lossCalc);
            }

            Console.WriteLine("AGI: " + (newTaxp.calculatedItems.adjustedGrossIncome = calcAGI()));

            //Calculate percentage withheld and penalize if applicable
            //  penalty is 10% of what is leftover

        }

        //New Record Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Save data
            if(tracker < SIZE)
            {
                saveData();
                this.Close();
            }
            else
            {
                MessageBox.Show("Max record limit reached. Record limit: " + SIZE
                    , "Max Entries Reached");
            }
        }

        private void saveData()
        {
            taxpArray[tracker++] = newTaxp;
        }

        private decimal percentageCalc(decimal val, double percentage)
        {
            return (val * (decimal)percentage);
        }

        private decimal calcAGI()
        {
            return newTaxp.taxItems.grossEarn -
                   newTaxp.calculatedItems.deductCalc -
                   newTaxp.calculatedItems.reCalc -
                   newTaxp.calculatedItems.exciseCalc -
                   newTaxp.calculatedItems.medCalc +
                   newTaxp.calculatedItems.gainsCalc -
                   newTaxp.calculatedItems.lossCalc;
        }

        private void graduatedTax()
        {
            decimal taxPercentage = 0;
            
            if(newTaxp.calculatedItems.adjustedGrossIncome > 0)
            {
                decimal temp = newTaxp.calculatedItems.adjustedGrossIncome;
                
                if(temp > (decimal)999.99)
                {
                    taxPercentage = (taxPercentage + (decimal)(999.99 * .10));
                    temp -= (decimal)999.99;
                    if(temp > (decimal)9999.99)
                    {
                        taxPercentage = (taxPercentage + (decimal)(9999.99 * .15));
                        temp -= (decimal)9999.99;
                    }
                    else
                    {
                        taxPercentage = (taxPercentage + (decimal));
                    }
                }
                else
                {
                    taxPercentage = (taxPercentage + (temp * (decimal).10));
                }
            }
        }


    }//End DisplayForm
}
