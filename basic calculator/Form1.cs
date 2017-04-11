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
            string btnName = "";
            if (sender == btn1) btnName = btnName + "1";
            else if (sender == btn2) btnName = "2";
            else if (sender == btn3) btnName = "3";
            else if (sender == btn4) btnName = "4";
            else if (sender == btn5) btnName = "5";
            else if (sender == btn6) btnName = "6";
            else if (sender == btn7) btnName = "7";
            else if (sender == btn8) btnName = "8";
            else if (sender == btn9) btnName = "9";
            else if (sender == btn0) btnName = "0";
            else if (sender == btnDecimal) btnName = btnName + ".";

            else if (sender == btnDivide) btnName = btnName + " / ";
            else if (sender == btnMultiply) btnName = btnName + " * ";
            else if (sender == btnSub) btnName = btnName + " - ";
            else if (sender == btnAdd) btnName = btnName + " + ";
            else if (sender == btnSign) Sign(display);//toggle positive /negative
            else if (sender == btnSqrt) Sqrt(display);//calculate and display square root
            else if (sender == btnReciprocal) Reciprocal(display);//calculate and display reciprocal
            else if (sender == btnEquals) Calculate(display);//calculate results of other equations
            
            display = display + btnName;
            txtDisplay.Text = display;
        }

        private void Calculate(string display)
        {
            throw new NotImplementedException();
            //use string to calculate result of equation
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
