using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    class Sum : Function
    {
        private List<Function> functions = new List<Function>();
        private List<Function> constants = new List<Function>();
        private double K = 0;

        public Sum(params Function[] terms)
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
            }
            for (int r = 0; r < constants.Count(); r++)
            {
                K += constants.ElementAt(r).evaluate(1);

            }
            if (K != 0)
            {
                functions.Add(new Constant(K));
            }
        }

        public Function derivative()
        {
            Function[] dervs = new Function[functions.Count()];
            for (int w = 0; w < functions.Count(); w++)
            {
                dervs[w] = functions.ElementAt(w).derivative();
            }
            if (dervs.Length == 1 && dervs[0].isConstant())
            {
                return new Constant(0);
            }
            else
            {

                return new Sum(dervs);
            }
        }


        public double evaluate(double x)
        {
            double eval = 0;
            for (int k = 0; k < functions.Count(); k++)
            {


                eval += functions.ElementAt(k).evaluate(x);
            }

            return eval;
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

        public String toString()
        {

            String result;

            result = functions.ElementAt(0).toString();


            for (int y = 1; y < functions.Count(); y++)
            {
                result = result + " + " + functions.ElementAt(y).toString();
            }


            return "(" + result + ")";
        }

        public double integral(double min, double max, int width)
        {
            double integral = 0;

            for (int u = 0; u < functions.Count(); u++)
            {
                integral += functions.ElementAt(u).integral(min, max, width);

            }
            return integral;
        }

    }
}
