using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlecsHaremCo.Components.Calculus
{
    interface Function
    {

        public double evaluate(double x);

        public String toString();

        public Function derivative();

        public bool isConstant();

        public double integral(double min, double max, int width);

    }
}
