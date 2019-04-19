using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM6004_CA4
{
    class MinFinder
    {
        static public double[] GradDescent(Func<double[], double> g, Func<double[], double[]> gp,
            double[] x, double alpha, int dim, double Tol, int N)
        {
            // Make a copy so that you don't  modify the original array.
            double[] xCopy = (double[])x.Clone();

            // Make a maximum of N iterations
            int numIterations = 0;
            while(numIterations++ < N)
            {

            }

            return new double[]{ };

        }
    }
}
