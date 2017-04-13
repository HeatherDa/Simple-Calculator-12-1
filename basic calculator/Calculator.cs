using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_calculator
{
    class Calculator
    {
        private string operation = "";//operator
        private decimal op1 = 0m;
        private decimal op2 = 0m;
        private bool sign;//set to show which operand's sign changes

        public Calculator()
        {
           
        }

        
        public decimal Op1
        {
            get {return op1;}
            set {op1 = value;}
        }

        public decimal Op2
        {
            get { return op2; }
            set { op2 = value; }
        }

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public bool Sign
        {
            get { return sign; }

            set
            {
                sign = value;
                if (sign) { op1=op1*-1; }//reverse sign of op1
                else { op2 = op2 * -1; }//reverse sign of op2
            }
        }

        public decimal Equals() //simple calculations
        {
            decimal answer = 0;
            switch (this.operation)
            {
                case "+":
                    answer = op1 + op2;
                    break;
                case "-":
                    answer = op1 - op2;
                    break;
                case "*":
                    answer = op1 * op2;
                    break;
                case "/"://already tested for divide by zero
                    answer = op1 / op2;
                    break;
            }
            op1 = answer; //answer is first number for next calculation
            return answer;
        }

        public decimal Sqrt() //sqrt calculation.  displays sqrt of a number
        {
            decimal answer = 0;
            double o = Convert.ToDouble(this.op1);
            o = Math.Sqrt(o);
            answer = Convert.ToDecimal(o);
            op1 = answer;
            return answer;
        }

        
        public decimal Reciprocal() //Reciprocal calculation. only works on 1 number
        {
            decimal answer = 0;
            answer = 1 / op1;
            op1 = answer;
            return answer;
        }

        internal void AllClear()
        {
            op1=0;
            op2 = 0;
            operation = "";
            sign = true;
        }
    }
}
