using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM6004_CA4
{
    class Program
    {
        static void Main(string[] args)
        {
            double alpha = 0.01;
            double Tol = 0.001;
            double N = 1000;
            double[] x0 = {-1, 2}; // Sure ??
            int dim = 2; // WTH is this ?

            MinFinder.GradDescent(BealesFunction, BealesPartialDerivative, x0, alpha, dim, Tol, N);
           
        }

        private static double BealesFunction(double[] xArray)
        {
            double x = xArray[0];
            double y = xArray[1];
            return Math.Pow((1.5 - x + x * y), 2) 
                + Math.Pow((2.25 - x + x * y * y), 2)
                + Math.Pow((2.625 - x + x * y * y * y), 2);
        }

        private static double[] BealesPartialDerivative(double[] xArray)
        {
            double x = xArray[0];
            double y = xArray[1];

            double dfdx = 2 * (1.5 - x + x * y) * (y - 1)
                + 2 * (2.25 - x + x * y * y) * (y * y - 1)
                + 2 * (2.625 - x + x * y * y * y) * (y * y * y - 1);

            double dfdy = 2 * (1.5 - x + x * y) * x
                + 2 * (2.25 - x + x * y * y) * 2 * x * y
                + 2*(2.625 - x + x * y * y * y) * 3 * x * y * y;

            return new double[] { dfdx, dfdy };
        }
    }
}
