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
            // Make a maximum of N iterations
            int numIterations = 0;
            double[] prevValueArray = {double.MinValue, double.MinValue};
            double[] newValueArray = { x[0], x[1] };

            while(numIterations++ < N && Math.Abs(g(prevValueArray) - g(newValueArray)) > Tol)
            {
                double[] gPrimes = gp(prevValueArray);
                double xGradient = gPrimes[0];
                double yGradient = gPrimes[1];

                if (xGradient == 0 || yGradient == 0)
                {
                    Console.WriteLine("Gradient is 0");
                    break;
                }

                double xPrev = prevValueArray[0];
                double yPrev = prevValueArray[1];

                double xNew = xPrev - alpha * xGradient;
                double yNew = yPrev - alpha * yGradient;

                // Copy the new values into the prev values
                Array.Copy(newValueArray, prevValueArray, newValueArray.Length);

                // replace the content of newValueArray with the new values.
                newValueArray[0] = xNew;
                newValueArray[1] = yNew;
            }

            if (numIterations == N)
            {
                Console.WriteLine("Max Iterations reached");
            }

            return newValueArray;

        }
    }
}
