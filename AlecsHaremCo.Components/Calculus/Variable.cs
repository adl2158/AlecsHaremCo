using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Variable : Function
    {
        private static Variable X = new Variable();

        private Variable()
        {

        }

        public double evaluate(double x)
        {
            return x;
        }

        public string toString()
        {
            return "X";
        }

        public Function derivative()
        {
            return new Constant(1);
        }

        public bool isConstant()
        {
            return false;
        }

        public double integral(double min, double max, int width)
        {
            double integral;
            integral = (Math.Pow(X.evaluate(max), 2) / 2) - (Math.Pow(X.evaluate(min), 2) / 2);

            return integral;
        }
    }
}
