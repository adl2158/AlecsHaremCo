using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Product : Function
    {
        private List<Function> functions = new List<Function>();
        private List<Function> constants = new List<Function>();
        private double K = 1;

        public Product(params Function[] terms)
        {

            for (int i = 0; i < terms.Length; i++)
            {
                if (terms[i].isConstant())
                {
                    constants.Add(terms[i]);
                }
                else
                {
                    functions.Add(terms[i]);

                }
                for (int r = 0; r < constants.Count(); r++)
                {
                    K *= constants.ElementAt(r).evaluate(1);

                }
                if (K != 1)
                {
                    functions.Add(new Constant(K));
                }
            }
        }


        public double evaluate(double x)
        {
            double eval = 1;
            for (int k = 0; k < functions.Count(); k++)
            {


                eval *= functions.ElementAt(k).evaluate(x);
            }

            return eval;
        }

        public string toString()
        {
            String result;

            result = functions.ElementAt(0).toString();


            for (int y = 1; y < functions.Count(); y++)
            {
                if (functions.ElementAt(y).toString().Equals("1.0"))
                {

                }
                else
                {
                    result = "(" + result + " * " + functions.ElementAt(y).toString() + ")";
                }

            }
            return result;
        }

        public Function derivative()
        {
            if (functions.Count() > 1)
            {
                Function[] gx = new Function[functions.Count() - 1];
                for (int w = 1; w < functions.Count(); w++)
                {
                    gx[w - 1] = functions.ElementAt(w);
                }
                return new Sum(new Product(functions.ElementAt(0), new Product(gx).derivative()), new Product(new Product(gx), functions.ElementAt(0).derivative()));
            }

            else
            {
                return functions.ElementAt(0).derivative();
            }
        }

        public bool isConstant()
        {
            if (functions.Count() == 1 && functions.ElementAt(0).isConstant())
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
