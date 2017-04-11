using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_calculator
{
    class Calculator
    {
        private List<decimal> operands = new List<decimal>();
        private string operation = "";//operator
        private decimal op1 = 0m;
        private decimal op2 = 0m;
        private bool prev = false;
        private bool error = true;

        public Calculator(/*string eq*/)
        {
            /*string[] equation = eq.Split(' ');
            if (prev)
            {
                ; //don't change op1 it
            }
            else if (!prev)
            {
                op1 = Decimal.Parse(equation[0]);
                operation = equation[1];
                op2 = Decimal.Parse(equation[2]);
            }*/
        }

        /*public void EnterValue(decimal op)
        {
            operands.Add(op);//put value in operands list
        }*/
        public decimal Op1
        {
            get {return op1;}
            set {op1 = value;}
        }
        public decimal Op1Set (string number)//this should be something for setting the value of op1, but not working?
        {
            if (DataValidation())
            {
                error = false;
                op1 = Decimal.Parse(number);
                return op1;//do I really need a return from this method?
            }
            else
            {
                error = true;
                return op1;//again, return?
            }
            
        }

        private bool DataValidation()
        {
            //test for entry (must have at least 1 number?)
            //test for decimal number
            //test operator for operator
            //if necessary, test for second entry
            throw new NotImplementedException();
        }
    }
}
