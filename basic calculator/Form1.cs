using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basic_calculator
{
    public partial class Form1 : Form
    {
        string display = "";
        Calculator c = new Calculator();
        bool goBack = true;
        string[] repeat = new string[3];
        string prevClick= "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Handler(object sender, EventArgs e)
        {
            string operand = "";
            if (sender == btn1) operand = operand + "1";
            else if (sender == btn2) operand = "2";
            else if (sender == btn3) operand = "3";
            else if (sender == btn4) operand = "4";
            else if (sender == btn5) operand = "5";
            else if (sender == btn6) operand = "6";
            else if (sender == btn7) operand = "7";
            else if (sender == btn8) operand = "8";
            else if (sender == btn9) operand = "9";
            else if (sender == btn0) operand = "0";
            else if (sender == btnDecimal) operand = operand + ".";
            else if (sender == btnDivide) operand = operand + " / ";
            else if (sender == btnMultiply) operand = operand + " * ";
            else if (sender == btnSub) operand = operand + " - ";
            else if (sender == btnAdd) operand = operand + " + ";
            goBack = true;
            display = display + operand;
            prevClick = operand;
            txtDisplay.Text = display;
        }

        private void Calculate()
        {
            string[] eq = StringSplit();
            if (dataValidation3(eq))
            {
                c.Op1 = Decimal.Parse(eq[0]); //set value of first operand
                c.Op2 = Decimal.Parse(eq[2]); //set second value
                c.Operation = eq[1]; //get operation type
                display = c.Equals().ToString();
                txtDisplay.Text = display;
                goBack = false;
                prevClick = "=";
                repeat[0] = display;//answer becomes first entry
                repeat[1] = eq[1];//previous operator becomes second entry
                repeat[2] = eq[2];//previous operator becomes third entry                                 
            }
        }

        private void EqualsAgain()
        {
            if (dataValidation(repeat))
            {
                display = c.Equals().ToString();
                txtDisplay.Text = display;
                goBack = false;
                prevClick = "=";
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            display = "";
            //goBack = true;
            c.AllClear();
            prevClick = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (goBack)//allowed to go back if calculation has not been completed.
            {

                display = display.Remove(display.Length - 1);//take last entry off
                txtDisplay.Text = display;
            }
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            String[] n = StringSplit();
            if (dataValidation(n))
            {
                c.Op1 = Decimal.Parse(n[0]);
                display = c.Sqrt().ToString();
                txtDisplay.Text = display;
                goBack = false;
                prevClick = "sq";
            }
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            String[] n = StringSplit();
            if (n.Length < 2) //we don't have a second op yet
            {
                c.Sign = true; //op1 gets changed
            }
            else { c.Sign = false; } //op2 gets changed
            //which operand do I add sign to for display?
            prevClick = "s";
        }

        private void Reciprocal_Click(object sender, EventArgs e)
        {
            String[] n = StringSplit();
            if (dataValidation(n)&& n[0] !="0")
            {
                c.Op1 = Decimal.Parse(n[0]);
                display = c.Reciprocal().ToString();
                txtDisplay.Text = display;
                goBack = false;
                prevClick = "r";
            }
            else if (n[0]=="0") //if operand would be 0, error message
            {
                MessageBox.Show("Cannot calculate Reciprocal of 0.", "Calculation Error");
            }
        }
        private string[] StringSplit()
        {
            return display.Split(' ');
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            if (prevClick != "=") { Calculate(); }
            else if (prevClick == "=") { EqualsAgain(); }
        }

        private bool dataValidation3(string[] eq)
        {
            if (isNotNull(eq)&& isDecimal(eq)) { return NotDivideByZero(eq); }//if first two fail, don't do third, or generates error.
            else { return false; }//if first two trials succeed, safe to try third.  else generates exception
        }
        private bool dataValidation(string[] eq)
        {
            return isDecimal(eq) && isNotNull1(eq);
        }

        private bool isNotNull1(string[] eq)
        {
            if(eq[0] != "") { return true; }
            else
            {
                MessageBox.Show("Please enter at least 1 number", "Entry Error");
                return false;
            }
        }

        private bool NotDivideByZero(string[] eq)
        {
            if (eq[2] =="0" && eq[1]=="/")//check for divide by zero
            {
                MessageBox.Show("Cannot Divide by Zero");
                return false;//divide by zero, so fails data validation
            }
            return true;//if above condition not met
        }

        private bool isNotNull(string[] eq)//use with equals
        {
            int count = 0;
            String erStr = "Please enter a number followed by an operator and another number.  Unless you are clicking equals a second time.";
            /*if (eq.Length < 3)
            {
                MessageBox.Show(erStr, "Entry Error");
                valid = false;
            }*/
            foreach (String s in eq)
            {
                if(eq.Length<3 || s == "")
                {
                    MessageBox.Show(erStr, "Entry Error");
                    count = count+1;
                }
            }
            if (count == 0) { return true; }
            else { return false; }
            
        }

        private bool isDecimal(string[] eq)//should contain operand1, operator, operand2 OR operand1, operator
        {
            Decimal deq = 0;
            if (eq.Length == 3 && Decimal.TryParse(eq[0], out deq) && Decimal.TryParse(eq[2], out deq)) { return true; } //if operand, operator, operand
            else if (eq.Length == 1 && Decimal.TryParse(eq[0], out deq)) { return true; } //operand1 and operator
            else
            {
                MessageBox.Show("Please enter a number.", "Entry Error");
                return false;
            }
        }
    }
}
