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

        public Calculator() { }

        public void EnterValue(decimal op)
        {
            operands.Add(op);//put value in operands list
        }
    }
}
