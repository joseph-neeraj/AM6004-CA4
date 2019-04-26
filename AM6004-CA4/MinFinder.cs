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
            double[] prevValueArray = { x[0], x[1] };
            double[] newValueArray = { x[0], x[1]};

            while(numIterations++ < N 
                && ((Math.Abs(g(prevValueArray) - g(newValueArray)) > Tol) || numIterations == 1)) // do not make the tolerance check if its the first iteration
            {
                double[] gPrimes = gp(newValueArray);
                double xGradient = gPrimes[0];
                double yGradient = gPrimes[1];

                if (xGradient == 0 || yGradient == 0)
                {
                    Console.WriteLine("Gradient is 0");
                    break;
                }

                double xPrev = newValueArray[0];
                double yPrev = newValueArray[1];

                double xNew = xPrev - alpha * xGradient;
                double yNew = yPrev - alpha * yGradient;

                Console.WriteLine("x, y, g = " + xNew + ", " + yNew + ", " + g(new double[] { xNew, yNew} ));

                // Copy the newValueArray into the prevValueArray
                Array.Copy(newValueArray, prevValueArray, newValueArray.Length);

                // replace the content of newValueArray with the new values.
                newValueArray[0] = xNew;
                newValueArray[1] = yNew;
            }

            Console.WriteLine("Num Iterations = " + numIterations);
            if (numIterations == N)
            {
                Console.WriteLine("Max Iterations reached");
            }

            return newValueArray;

        }

        static public double[] GradDescentMOM(Func<double[], double> g, Func<double[], double[]>gp,
            double[] x, double alpha, double gamma, int dim, double Tol, int N)
        {
            // Make a maximum of N iterations
            int numIterations = 0;
            double[] prevValueArray = { x[0], x[1] };
            double[] newValueArray = { x[0], x[1] };

            double vix = 0;
            double viy = 0;

            while (numIterations++ < N
               && ((Math.Abs(g(prevValueArray) - g(newValueArray)) > Tol) || numIterations == 1)) // do not make the tolerance check if its the first iteration
            {
                double[] gPrimes = gp(newValueArray);
                double xGradient = gPrimes[0];
                double yGradient = gPrimes[1];

                if (xGradient == 0 || yGradient == 0)
                {
                    Console.WriteLine("Gradient is 0");
                    break;
                }

                double xPrev = newValueArray[0];
                double yPrev = newValueArray[1];

                vix = gamma * vix + alpha * xGradient;
                viy = gamma * viy + alpha * yGradient;

                double xNew = xPrev - vix;
                double yNew = yPrev - viy;

                Console.WriteLine("x, y, g = " + xNew + ", " + yNew + ", " + g(new double[] { xNew, yNew }));

                // Copy the newValueArray into the prevValueArray
                Array.Copy(newValueArray, prevValueArray, newValueArray.Length);

                // replace the content of newValueArray with the new values.
                newValueArray[0] = xNew;
                newValueArray[1] = yNew;
            }

            Console.WriteLine("NumIterations " + numIterations);

            if (numIterations == N)
            {
                Console.WriteLine("Max Iterations reached");
            }

            return newValueArray;
        }
    }
}
