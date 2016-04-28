using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    // Model
    class Calculator
    {
        private double left = 0;
        private double right = 0;
        public double Result { get; private set; } = 0;

        private Func<double, double, double> operation;

        private bool operationDeclared = false;

        public double Operand
        {
            set
            {
                if (operationDeclared)
                {
                    right = value;
                }
                else
                {
                    left = value;
                }
            }
        }

        public void SetAdd()
        {
            operation = (left, right) => left + right;
            operationDeclared = true;
        }

        public void Execute()
        {
            Result = operation(left, right);
            left = Result;
            operation = null;
            operationDeclared = false;
        }
    }
}
