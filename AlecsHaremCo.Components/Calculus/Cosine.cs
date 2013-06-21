using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Cosine : Function
    {
        private Function term;

        public Cosine(Function f)
        {
            term = f;
        }


        public double evaluate(double x)
        {
            return Math.Cos(term.evaluate(x));
        }

        public string toString()
        {
            return "Cos( " + term.toString() + " )";
        }

        public Function derivative()
        {
            return new Product(term.derivative(), new Constant(-1), new Sine(term));
        }

        public bool isConstant()
        {
            if (term.isConstant())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double integral(double min, double max, int width)
        {
            double delta = (max - min) / width;
            double trapint = 0;
            int inc = 1;

            trapint += this.evaluate(min);

            for (int m = 0; m < width - 1; m++)
            {
                trapint += 2 * this.evaluate(min + (delta * inc));
                inc++;
            }

            trapint += this.evaluate(max);

            return (delta * .5) * trapint;
        }
    }
}
