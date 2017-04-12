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
            else if (sender == btnSign) Sign();//toggle positive /negative
            else if (sender == btnSqrt) Sqrt();//calculate and display square root
            else if (sender == btnReciprocal) Reciprocal();//calculate and display reciprocal
            else if (sender == btnEquals) Calculate();//calculate results of other equations


            display = display + operand;
            txtDisplay.Text = display;
            goBack = true;//not working somewhere....
        }

        private void AC()
        {
            txtDisplay.Text="";
            display = "";
            goBack = true;
            c.AllClear();

        }

        private void Calculate()
        {
            //throw new NotImplementedException();
            //use string to calculate result of equation

            string[] eq = StringSplit();
            if (dataValidation(eq))
            {
                c.Op1 = Decimal.Parse(eq[0]); //set value of first operand
                c.Op2 = Decimal.Parse(eq[2]); //set second value
                c.Operation = eq[1]; //get operation type
                display = c.Equals().ToString();
                txtDisplay.Text = display;
                goBack = false;
            }

        }

        private string[] StringSplit()
        {
            return display.Split(' ');
        }

        private bool dataValidation(string[] eq)
        {
            return isDecimal(eq) && isNotNull(eq) && NotDivideByZero(eq);
        }

        private bool NotDivideByZero(string[] eq)
        {
            if (eq[2].Contains("0") && eq[1].Contains("/"))//check for divide by zero
            {
                MessageBox.Show("Cannot Divide by Zero");
                return false;//divide by zero, so fails data validation
            }
            return true;//if above condition not met
        }

        private bool isNotNull(string[] eq)
        {
            if (eq.Length >=2) { return true; }
            else
            {
                MessageBox.Show("Please enter your equation before calculating");
                return false;
            }//doesn't test for it being 1 or 2 or 3....
        }

        private bool isDecimal(string[] eq)//should contain operand1, operator, operand2 OR operand1, operator
        {
            Decimal deq = 0;
            if (eq.Length == 3 && Decimal.TryParse(eq[0], out deq) && Decimal.TryParse(eq[2], out deq)) { return true; } //if operand, operator, operand
            else if (eq.Length == 2 && Decimal.TryParse(eq[0], out deq)) { return true; } //operand1 and operator
            else { return false; }
        }

        private void Sign()//toggle sign True = Positive, False = Negative
        {
            String[] n= StringSplit();
            if (n.Length < 2) //we don't have a second op yet
            {
                c.Sign=true; //op1 gets changed
            }
            else { c.Sign = false; } //op2 gets changed
            //which operand do I add sign to for display?
        }

        private void Reciprocal()//calculate reciprocal
        {
            String[] n=StringSplit();
            c.Op1=Decimal.Parse(n[0]);
            display=c.Reciprocal().ToString();
            txtDisplay.Text = display;
            goBack = false;
        }

        private void Sqrt()//calculate square root
        {
            String[] n = StringSplit();
            c.Op1 = Decimal.Parse(n[0]);
            display = c.Sqrt().ToString();
            txtDisplay.Text = display;
            goBack = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AC();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (goBack)//allowed to go back if calculation has not been completed.
            {
                display = display.Remove(display.Length - 1);//take last entry off
            }
        }
    }
}
