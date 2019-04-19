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

            //MinFinder.GradDescent(BealesFunction, BealesPartialDerivative, x0, alpha, dim, Tol, N);
            int i = 0;
            int count = 0;
            while(i++ < 5)
            {
                Console.WriteLine(count++);
            }

            count = 0;
            while(++i < 5)
            {
                Console.WriteLine(count++);
            }

            Console.Read();
        }

        private static double BealesFunction(double[] x)
        {
            return Math.Pow((1.5 - x[0] + x[0] * x[1]), 2) 
                + Math.Pow((2.25 - x[0] + x[0] * x[1] * x[1]), 2)
                + Math.Pow((2.625 - x[0] + x[0] * x[1] * x[1] * x[1]), 2);
        }

        private static double[] BealesPartialDerivative(double[] x)
        {
            return new double[] { };
        }
    }
}
