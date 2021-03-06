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
        
        private decimal adjustedGrossIncome;
        private decimal reCalc;
        private decimal exciseCalc;
        private decimal deductCalc;
        private decimal medCalc;
        private decimal gainsCalc;
        private decimal lossCalc;
        private decimal penalty;
        private decimal owedOrRefund;
        private decimal taxOnAGI;
        
        private const int SIZE = 10;
        public static taxpayerFinal[] taxpArray = new taxpayerFinal[SIZE];
        public static int endIndex = 0;
        private taxpayer newTaxp;
        private decimal percentageOfTaxPaid;
        private bool isSaved;

        public DisplayForm()
        {
            InitializeComponent();
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            newTaxp = InputForm.getTaxpayerInfo();
            isSaved = false;
            label7.Text = "Calculated tax information for:\n" + newTaxp.name;

            if(endIndex == 0)
            {
                btnView.Enabled = false;
                initializeArray();
            }else
            {
                btnView.Enabled = true;
            }

            calculateFromTaxItems();

            if (adjustedGrossIncome < 0)
            {
                MessageBox.Show("There was an error with this record.\n" +
                                "AGI value: " + adjustedGrossIncome + "\n" +
                                "Please check record and refile or seek legal assistance.", "AGI Error");
                this.Close();
            }

            roundToWholeDollar();

            assignToTextBox();


        }//End Form_load

        //New Record Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Save data
            if(endIndex < SIZE)
            {
                if (!isSaved)
                {
                    System.Windows.Forms.DialogResult saveRecord;
                    saveRecord = MessageBox.Show("You have data entered here. Save data?", "Save data",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(saveRecord == System.Windows.Forms.DialogResult.Yes)
                    {
                        isSaved = saveDataProcess();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Max record limit reached. Record limit: " + SIZE
                    , "Max Entries Reached");
            }
        }

        private void saveData()
        {
            if(endIndex < SIZE)
            {
                taxpayerFinal final = new taxpayerFinal();
                final.name = newTaxp.name;
                final.ssn = newTaxp.ssn;
                if (lblOwedRefund.Text.Equals("Tax Owed:"))
                {
                    final.owedOrRefunded = (-1m * owedOrRefund);
                }
                else
                {
                    final.owedOrRefunded = owedOrRefund;
                }

                taxpArray[endIndex++] = final;
                sortArray();
            }
        }

        private decimal percentageCalc(decimal val, double percentage)
        {
            return (val * (decimal)percentage);
        }

        private decimal calcAGI()
        {
            return newTaxp.taxItems.grossEarn -
                   deductCalc -
                   reCalc -
                   exciseCalc -
                   medCalc +
                   gainsCalc -
                   lossCalc;
        }

        private decimal graduatedTax()
        {
            decimal taxOnGross = 0;
            
            if(adjustedGrossIncome > 0)
            {
                decimal temp = adjustedGrossIncome;
                
                if(temp > 999.99m)
                {
                    taxOnGross = (taxOnGross + (decimal)(999.99 * .10));
                    temp -= 999.99m;
                    Console.WriteLine("First tax Bracket: " + taxOnGross);
                    Console.WriteLine("temp value: " + temp);

                    if(temp > 9999.99m)
                    {
                        taxOnGross = (taxOnGross + (decimal)(9999.99 * .15));
                        temp -= 9999.99m;
                        Console.WriteLine("Second tax Bracket: " + taxOnGross);
                        Console.WriteLine("temp value: " + temp);

                        if (temp > 19999.99m)
                        {
                            taxOnGross = (taxOnGross + (decimal)(19999.99 * .20));
                            temp -= 19999.99m;
                            Console.WriteLine("Third tax Bracket: " + taxOnGross);
                            Console.WriteLine("temp value: " + temp);

                            if (temp > 29999.99m)
                            {
                                taxOnGross = (taxOnGross + (decimal)(29999.99 * .25));
                                temp -= 29999.99m;
                                Console.WriteLine("Fourth tax Bracket: " + taxOnGross);
                                Console.WriteLine("temp value: " + temp);

                                if (temp > 0)
                                {
                                    taxOnGross = taxOnGross + (temp * 0.28m);
                                    Console.WriteLine("Last tax Bracket: " + taxOnGross);
                                    Console.WriteLine("temp value: " + temp);
                                }
                            }
                            else
                            {
                                taxOnGross = (taxOnGross + 0.25m);
                                Console.WriteLine("Fourth tax Bracket: " + taxOnGross);
                                Console.WriteLine("temp value: " + temp);
                            }
                        }else
                        {
                            taxOnGross = (taxOnGross + 0.20m);
                            Console.WriteLine("Third tax Bracket: " + taxOnGross);
                            Console.WriteLine("temp value: " + temp);
                        }
                    }
                    else
                    {
                        taxOnGross = (taxOnGross + 0.15m);
                        Console.WriteLine("Second tax Bracket: " + taxOnGross);
                        Console.WriteLine("temp value: " + temp);
                    }
                }
                else
                {
                    taxOnGross = (taxOnGross + (temp * 0.10m));
                    Console.WriteLine("First tax Bracket: " + taxOnGross);
                    Console.WriteLine("temp value: " + temp);
                }
            }

            return taxOnGross;

        }//End graduatedTax
        
        private decimal taxPercentagePaid()
        {
            if(taxOnAGI <= 0)
            {
                return 0.00m;
            }else
            {
                return newTaxp.taxItems.taxWithheld / taxOnAGI;
            } 
        }

        //Unsure
        private decimal calcOwedOrRefund()
        {
            decimal temp = newTaxp.taxItems.taxWithheld - taxOnAGI;
            //calculate refund
            if (temp > 0m)
            {
                return temp; //refund amount
            }
            else {//calculate tax owed
                
                return (taxOnAGI - newTaxp.taxItems.taxWithheld) + penalty;
            }
        }

        private bool isThereARefund()
        {
            return newTaxp.taxItems.taxWithheld > taxOnAGI;
        }

        private void calculateFromTaxItems()
        {
            //Calculate each deduction at 1000
            if (newTaxp.exemptions != 0)
            {
                deductCalc = (decimal)(newTaxp.exemptions * 1000.00);
            }

            //Calculate Real Estate Tax
            if (newTaxp.taxItems.realEstate != 0)
            {
                reCalc = percentageCalc(newTaxp.taxItems.realEstate, 0.25);
            }

            //Calculate Excise Tax
            if (newTaxp.taxItems.excise != 0)
            {
                exciseCalc = percentageCalc(newTaxp.taxItems.excise, 0.25);
            }

            //Deduction for medical
            if (newTaxp.taxItems.medicalExpense != 0)
            {
                medCalc = percentageCalc(newTaxp.taxItems.medicalExpense, 0.08);
            }

            //Add 15% for capital gains to gross(if present)
            if (newTaxp.taxItems.gains != 0)
            {
                gainsCalc = percentageCalc(newTaxp.taxItems.gains, 0.15);
            }

            //Sub 15% for capital loss to gross(if present)
            if (newTaxp.taxItems.loss != 0)
            {
                lossCalc = percentageCalc(newTaxp.taxItems.loss, 0.15);
            }


            adjustedGrossIncome = calcAGI();
            
            taxOnAGI = graduatedTax();

            //Calculate percentage withheld and penalize if applicable
            //  penalty is 10% of what is leftover
            percentageOfTaxPaid = taxPercentagePaid();

            //If the precentageOfTaxPaid is less than 90% add a 10% penalty on the difference
            if (Math.Round(percentageOfTaxPaid, 2, MidpointRounding.AwayFromZero) < 0.90m)
            {
                penalty = (taxOnAGI - newTaxp.taxItems.taxWithheld) * 0.10m;
                
            }
            else
            {
                penalty = 0.00m;
                
            }

            if (isThereARefund())//there is a refund
            {
                owedOrRefund = calcOwedOrRefund();
                lblOwedRefund.Text = "Refund:";
            }
            else //there is tax owed
            {
                owedOrRefund = calcOwedOrRefund();
                lblOwedRefund.Text = "Tax Owed:";
                
            }
        }

        private void roundToWholeDollar()
        {
            newTaxp.taxItems.taxWithheld = Math.Round(newTaxp.taxItems.taxWithheld, 0, MidpointRounding.AwayFromZero);

            adjustedGrossIncome = Math.Round(adjustedGrossIncome, 0, MidpointRounding.AwayFromZero);

            taxOnAGI = Math.Round(taxOnAGI, 0, MidpointRounding.AwayFromZero);

            penalty = Math.Round(penalty, 0, MidpointRounding.AwayFromZero);

            owedOrRefund = Math.Round(owedOrRefund, 0, MidpointRounding.AwayFromZero);
        }

        private void assignToTextBox()
        {
            tbWithheld.Text = newTaxp.taxItems.taxWithheld.ToString("c");
            //tbWithheld.Enabled = false;

            tbAGI.Text = adjustedGrossIncome.ToString("c");
            //tbAGI.Enabled = false;

            tbCalcTax.Text = taxOnAGI.ToString("c");
            //tbCalcTax.Enabled = false;

            tbPenalty.Text = penalty.ToString("c");
            //tbPenalty.Enabled = false;

            tfOwedRefund.Text = owedOrRefund.ToString("c");
            //tfOwedRefund.Enabled = false;
        }
        
        //View Records Button
        private void button2_Click(object sender, EventArgs e)
        {
            //close this window
            Close();

            //Open a dialog window that displays information in a sorted way
            DisplayRecords displayRecords = new DisplayRecords();
            displayRecords.ShowDialog();
        }

        private void initializeArray()
        {
            taxpayerFinal temp = new taxpayerFinal();
            temp.name = "";
            temp.ssn = "";
            temp.owedOrRefunded = 0.00m;
            for (int i = 0; i < SIZE; i++)
            {
                taxpArray[i] = temp;
            }
        }

        private void sortArray()
        {
            int index = endIndex - 1;
            for(; index > 0; index--)
            {

                if (taxpArray[index].ssn.CompareTo(taxpArray[index-1].ssn) == -1)
                {

                    taxpayerFinal temp = taxpArray[index];
                    taxpArray[index] = taxpArray[index - 1];
                    taxpArray[index-1] = temp;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            isSaved = saveDataProcess();

        }

        private bool saveDataProcess()
        {
            saveData();
            if (endIndex > 0)
            {
                btnView.Enabled = true;
            }
            else
            {
                btnView.Enabled = false;
            }

            return true;
        }
    }//End DisplayForm
}
