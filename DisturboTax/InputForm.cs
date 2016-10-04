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
    public struct taxitems
    {
        public decimal grossEarn;
        public decimal taxWithheld;

        public decimal gains;
        public decimal loss;
        public decimal excise;

        public decimal realEstate;
        public decimal medicalExpense;
    }

    public struct taxpayer
    {
        public String name;
        public String address;
        public String city;
        public String state;
        public String zipcode;
        public String ssn;
        public int exemptions;
        public decimal adjustedGrossIncome;
        public taxitems taxItems;
    }

    

    public partial class InputForm : Form
    {
        static taxpayer taxp = new taxpayer();

        public InputForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadStates();
            if (true)
                DEBUGFORM();
        }

        //Calculate button
        private void button1_Click(object sender, EventArgs e)
        {
            taxp.name = nameBox.Text;
            taxp.address = addressBox.Text;
            taxp.city = cityBox.Text;
            taxp.state = cobState.Text;
            
            try
            {
                if (isValidData())
                {
                    taxp.zipcode = zipBox.Text;
                    taxp.ssn = ssnBox.Text;
                    taxp.exemptions = Convert.ToInt32(exemptionsBox.Text);

                    taxp.taxItems.grossEarn = Convert.ToDecimal(grossEarningsBox.Text);
                    taxp.taxItems.taxWithheld = Convert.ToDecimal(withheldBox.Text);

                    taxp.taxItems.gains = Convert.ToDecimal(gainsBox.Text);
                    taxp.taxItems.loss = Convert.ToDecimal(lossBox.Text);
                    taxp.taxItems.excise = Convert.ToDecimal(exciseBox.Text);

                    taxp.taxItems.realEstate = Convert.ToDecimal(reBox.Text);
                    taxp.taxItems.medicalExpense = Convert.ToDecimal(medicalBox.Text);

                    //Create second form as a dialog box
                    DisplayForm display = new DisplayForm();
                    display.ShowDialog();
                    clearFields();
                    DEBUGFORMTWO();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured. Please review data", "Error in Field");
                nameBox.Focus();
            }
        }

        //Clear button
        private void button3_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void loadStates()
        {
            String[] stateID = {    "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA",
                                    "HI","ID","IL","IN","IA","KS","KY","LA","ME","MD",
                                    "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
                                    "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC",
                                    "SD","TN","TX","UT","VT","VA","WA","WV","WI","WY"   };

            for(int i = 0; i < stateID.Length; i++)
            {
                cobState.Items.Add(stateID[i]);
            }
            cobState.SelectedIndex = -1;
        }

        public void clearFields()
        {
            nameBox.Text = "";
            addressBox.Text = "";
            cityBox.Text = "";
            cobState.SelectedIndex = -1;
            zipBox.Text = "";
            ssnBox.Text = "";
            exemptionsBox.Text = "";

            grossEarningsBox.Text = "";
            withheldBox.Text = "";

            gainsBox.Text = "";
            lossBox.Text = "";
            exciseBox.Text = "";

            reBox.Text = "";
            medicalBox.Text = "";
            nameBox.Focus();
        }

        private bool isValidData()
        {
            return isPresent(nameBox, "Name") &&
                   isPresent(addressBox, "Address") &&
                   isPresent(cityBox, "City") &&
                   isSelected(cobState, "State") &&

                   isPresent(zipBox, "Zipcode") &&
                   isCorrectLength(zipBox, "Zipcode", 5) &&
                   isInt32(zipBox, "Zipcode") &&

                   isPresent(ssnBox, "SSN") &&
                   isCorrectLength(ssnBox, "SSN", 10) &&
                   isInt32(ssnBox, "SSN") &&

                   isPresent(exemptionsBox, "Exemptions") &&
                   isInt32(exemptionsBox, "Exemptions") &&
                   isInRange(exemptionsBox, 0, 10) &&

                   isPresent(grossEarningsBox, "Gross Earnings") &&
                   isDecimal(grossEarningsBox, "Gross Earnings") &&

                   isPresent(withheldBox, "Tax Withheld") &&
                   isDecimal(withheldBox, "Tax Withheld") &&

                   isPresent(gainsBox, "Capital Gains") &&
                   isDecimal(gainsBox, "Capital Gains") &&

                   isPresent(lossBox, "Capital Loss") &&
                   isDecimal(lossBox, "Capital Loss") &&

                   isPresent(exciseBox, "Excise Tax")&&
                   isDecimal(exciseBox, "Excise Tax") &&

                   isPresent(reBox, "Real Estate Tax") &&
                   isDecimal(reBox, "Real Estate Tax") &&                   
                   
                   isPresent(medicalBox, "Medical Expenses") &&
                   isDecimal(medicalBox, "Medical Expenses");
        }

        private bool isPresent(TextBox textBox, String name)
        {
            if(textBox.Text == "")
            {
                MessageBox.Show("Value in " + name + " field is required.", name + " Error");
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }
        
        private bool isSelected(ComboBox cBox, String name)
        {
            if(cBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a " + name + ".", name + " Error");
                return false;
            }
            return true;
        }
        
        private bool isDecimal(TextBox textBox, String name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }catch(FormatException)
            {
                MessageBox.Show("Invalid input in " + name + " field. Omit \"$\".", name + "Error");
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
        }

        private bool isCorrectLength(TextBox textBox, String name, int len)
        {
            String format = "";
            for(int i = 0; i < len; i++)
            {
                format += i.ToString();
            }
            if(textBox.Text.Length != len)
            {
                MessageBox.Show("Value in " + name + " field is invalid. It must be " + len + 
                                " characters long.\n" +
                                "Correct format: " + format, name + " Error");
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }

        private bool isInt32(TextBox textBox, String name)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Value in " + name + " field is invalid.", name + " Error");
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
        }

        private bool isInRange(TextBox textBox, int min, int max)
        {
            int temp = Convert.ToInt32(textBox.Text);
            if (temp < min || temp > max) {
                MessageBox.Show("Value out of range. Accepted range: " + min + " to " + max + "."
                    , "Range Error");
                textBox.Text = "";
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static taxpayer getTaxpayerInfo() { return taxp; }

        private void DEBUGFORM()
        {
            nameBox.Text = "John";
            addressBox.Text = "64 Happy Land";
            cityBox.Text = "City";
            cobState.SelectedIndex = 8;
            zipBox.Text = "12345";
            ssnBox.Text = "1234567890";
            exemptionsBox.Text = "3";

            grossEarningsBox.Text = "1234.45";
            withheldBox.Text = "1234.0";

            gainsBox.Text = "123.00";
            lossBox.Text = "123.00";
            exciseBox.Text = "0.0";

            reBox.Text = "0.0";
            medicalBox.Text = "0.0";
            button1.Focus();
        }

        private void DEBUGFORMTWO()
        {
            nameBox.Text = "Mary";
            addressBox.Text = "64 Sad Land";
            cityBox.Text = "City";
            cobState.SelectedIndex = 8;
            zipBox.Text = "12345";
            ssnBox.Text = "1234567890";
            exemptionsBox.Text = "3";

            grossEarningsBox.Text = "1234.45";
            withheldBox.Text = "1234.0";

            gainsBox.Text = "123.00";
            lossBox.Text = "123.00";
            exciseBox.Text = "0.0";

            reBox.Text = "0.0";
            medicalBox.Text = "0.0";
            button1.Focus();
        }
    }
}
