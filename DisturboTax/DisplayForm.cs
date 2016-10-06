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
        private decimal percentageOfTaxPaid;

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
            Console.WriteLine("Tax on AGI: " + (newTaxp.calculatedItems.taxOnAGI = graduatedTax()));

            //Calculate percentage withheld and penalize if applicable
            //  penalty is 10% of what is leftover
            percentageOfTaxPaid = taxPercentagePaid();
            Console.WriteLine("Tax Percentage Paid: " + percentageOfTaxPaid);

            //If the precentageOfTaxPaid is less than 90% add a 10% penalty on the difference
            if (Math.Round(percentageOfTaxPaid, 2, MidpointRounding.AwayFromZero) < (decimal).90)
            {
                newTaxp.calculatedItems.penalty = (newTaxp.calculatedItems.taxOnAGI - newTaxp.taxItems.taxWithheld) * (decimal).10;
                Console.WriteLine("Penalty: " + newTaxp.calculatedItems.penalty);
            }
            
            if(isThereARefund())//there is a refund
            {
                newTaxp.calculatedItems.penalty = 0.00m;
                newTaxp.calculatedItems.owedOrRefund = calcOwedOrRefund();
                Console.WriteLine("Penalty: " + newTaxp.calculatedItems.penalty);
                Console.WriteLine("Refund value: " +
                    Math.Round(newTaxp.calculatedItems.owedOrRefund, 2, MidpointRounding.AwayFromZero));
            }
            else //there is tax owed
            {
                newTaxp.calculatedItems.owedOrRefund = calcOwedOrRefund();
                Console.WriteLine("Penalty: " + newTaxp.calculatedItems.owedOrRefund);
                Console.WriteLine("Tax Owed value: " +
                    Math.Round(newTaxp.calculatedItems.owedOrRefund, 2, MidpointRounding.AwayFromZero));
            }
            

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

        private decimal graduatedTax()
        {
            decimal taxOnGross = 0;
            
            if(newTaxp.calculatedItems.adjustedGrossIncome > 0)
            {
                decimal temp = newTaxp.calculatedItems.adjustedGrossIncome;
                
                if(temp > (decimal)999.99)
                {
                    taxOnGross = (taxOnGross + (decimal)(999.99 * .10));
                    temp -= (decimal)999.99;
                    Console.WriteLine("First tax Bracket: " + taxOnGross);
                    Console.WriteLine("temp value: " + temp);

                    if(temp > (decimal)9999.99)
                    {
                        taxOnGross = (taxOnGross + (decimal)(9999.99 * .15));
                        temp -= (decimal)9999.99;
                        Console.WriteLine("Second tax Bracket: " + taxOnGross);
                        Console.WriteLine("temp value: " + temp);

                        if (temp > (decimal)19999.99)
                        {
                            taxOnGross = (taxOnGross + (decimal)(19999.99 * .20));
                            temp -= (decimal)19999.99;
                            Console.WriteLine("Third tax Bracket: " + taxOnGross);
                            Console.WriteLine("temp value: " + temp);

                            if (temp > (decimal)29999.99)
                            {
                                taxOnGross = (taxOnGross + (decimal)(29999.99 * .25));
                                temp -= (decimal)29999.99;
                                Console.WriteLine("Fourth tax Bracket: " + taxOnGross);
                                Console.WriteLine("temp value: " + temp);

                                if (temp > 0)
                                {
                                    taxOnGross = taxOnGross + (temp * (decimal).28);
                                    Console.WriteLine("Last tax Bracket: " + taxOnGross);
                                    Console.WriteLine("temp value: " + temp);
                                }
                            }
                            else
                            {
                                taxOnGross = (taxOnGross + (decimal).25);
                                Console.WriteLine("Fourth tax Bracket: " + taxOnGross);
                                Console.WriteLine("temp value: " + temp);
                            }
                        }else
                        {
                            taxOnGross = (taxOnGross + (decimal).20);
                            Console.WriteLine("Third tax Bracket: " + taxOnGross);
                            Console.WriteLine("temp value: " + temp);
                        }
                    }
                    else
                    {
                        taxOnGross = (taxOnGross + (decimal).15);
                        Console.WriteLine("Second tax Bracket: " + taxOnGross);
                        Console.WriteLine("temp value: " + temp);
                    }
                }
                else
                {
                    taxOnGross = (taxOnGross + (temp * (decimal).10));
                    Console.WriteLine("First tax Bracket: " + taxOnGross);
                    Console.WriteLine("temp value: " + temp);
                }
            }

            return taxOnGross;

        }//End graduatedTax
        
        private decimal taxPercentagePaid()
        {

            return  newTaxp.taxItems.taxWithheld / newTaxp.calculatedItems.taxOnAGI;
        }

        //Unsure
        private decimal calcOwedOrRefund()
        {
            decimal temp = newTaxp.taxItems.taxWithheld - (newTaxp.calculatedItems.taxOnAGI * .90m);
            //calculate refund
            if (temp > 0m)
            {
                return temp; //refund amount
            }
            else {//calculate tax owed

                return ((newTaxp.calculatedItems.taxOnAGI * .90m) - newTaxp.taxItems.taxWithheld) + newTaxp.calculatedItems.penalty;
            }
        }

        private bool isThereARefund()
        {
            return newTaxp.taxItems.taxWithheld > newTaxp.calculatedItems.taxOnAGI;
        }

    }//End DisplayForm
}
