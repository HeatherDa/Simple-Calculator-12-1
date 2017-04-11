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
            else if (sender == btnSign) Sign(display);//toggle positive /negative
            else if (sender == btnSqrt) Sqrt(display);//calculate and display square root
            else if (sender == btnReciprocal) Reciprocal(display);//calculate and display reciprocal
            else if (sender == btnEquals) Calculate(display);//calculate results of other equations
            
            display = display + operand;
            txtDisplay.Text = display;
        }

        private void Calculate(string display)
        {
            //throw new NotImplementedException();
            //use string to calculate result of equation
            Calculator c = new Calculator();
            String[] eq = display.Split(' ');
            if (dataValidation(eq))
            {
                c.Op1 = Decimal.Parse(eq[0]); //set value of first operand
            }

        }

        private bool dataValidation(string[] eq)
        {
            //throw new NotImplementedException();
            return isDecimal(eq) && isNotNull(eq);
        }

        private bool isNotNull(string[] eq)
        {
            if (eq.Length !=0) { return true; }
            else
            {
                MessageBox.Show("Please enter your equation before calculating");
                return false;
            }//doesn't test for it being 1 or 2 or 3....
        }

        private bool isDecimal(string[] eq)//fix me
        {
            Decimal deq = 0;
            if (eq.Length == 3 && Decimal.TryParse(eq[0], out deq)) { return true; }//???
            //throw new NotImplementedException();
            else if (eq.Length == 3 && Decimal.TryParse(eq[2], out deq)) { return false; }//???
        }

        private void Sign(string display)//toggle sign
        {
            throw new NotImplementedException();
            //set display to result
        }

        private void Reciprocal(string btnName)//calculate reciprocal
        {
            throw new NotImplementedException();
            //set display to result
        }

        private void Sqrt(string btnName)//calculate square root
        {
            throw new NotImplementedException();
            //set display to result
        }
    }
}
