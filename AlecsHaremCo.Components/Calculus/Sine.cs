using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Sine : Function
    {
        private Function term;

        public Sine(Function f)
        {
            term = f;

        }


        public double evaluate(double x)
        {
            return Math.Sin(term.evaluate(x));
        }

        public string toString()
        {
            return "Sin( " + term.toString() + " )";
        }

        public Function derivative()
        {
            return new Product(term.derivative(), new Cosine(term));
        }

        public bool isConstant()
        {
            if (term.isConstant() == true)
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
