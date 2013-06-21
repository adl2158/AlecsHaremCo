using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Constant : Function
    {
        private double C;


        public Constant(double value)
        {
            C = value;

        }

        public double evaluate(double x)
        {
            return C;
        }

        public string toString()
        {
            return C.ToString();
        }

        public Function derivative()
        {
            return new Constant(0);
        }

        public bool isConstant()
        {
            return true;
        }

        public double integral(double min, double max, int width)
        {
            return (max * C - min * C);
        }
    }
}
