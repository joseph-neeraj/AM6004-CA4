using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AM6004_CA4
{
    class Program
    {
        static void Main(string[] args)
        {
            RunGradientDescent();
            Console.WriteLine();

            RunGradientDescentWithMom();
            Console.WriteLine();

            RunNonLinearShooting();
       
            Console.ReadLine();
        }

        private static void RunGradientDescent()
        {
            double alpha = 0.01;
            double Tol = 0.001;
            int N = 1000;
            double[] x0 = { -1, 2 };
            int dim = 2;

            Console.WriteLine("Running Gradient Descent...");
            double[] gradDescentResult = MinFinder.GradDescent(BealesFunction, BealesPartialDerivative, new double[] { -1, 2 }
            , alpha, dim, Tol, N);
            Console.WriteLine("Done !!");
            Console.WriteLine("Gradient Descent Result : " + gradDescentResult[0] + "," + gradDescentResult[1]);
        }

        private static void RunGradientDescentWithMom()
        {
            double alpha = 0.01;
            double gamma = 0.8;
            double Tol = 0.001;
            int N = 1000;
            double[] x0 = { -1, 2 };
            int dim = 2;

            Console.WriteLine("Running Gradient Descent With Momentum..");
            double[] gradDescentMomResult = MinFinder.GradDescentMOM(BealesFunction, BealesPartialDerivative
                , x0, alpha, gamma, dim, Tol, N);
            Console.WriteLine("Done !!");
            Console.WriteLine("Gradient Descent with momentum Result : " + gradDescentMomResult[0] + "," + gradDescentMomResult[1]);
        }

            private static void RunNonLinearShooting()
        {
            double a = 0;
            double b = 2;
            double alpha = 0;
            double beta = 1;
            int N = 10;
            int MaxIt = 100;
            double Tol = 0.0001;

            Console.WriteLine("Running Non Linear Shooting with Newton's Method: ");
            double[,] shootingResult = Newton.NonLinearShooting(f, fy, fyp, a, b, alpha, beta, N, MaxIt, Tol);

            double[] t = new double[N + 1];
            double h = (b - a) / N;
            for (int i = 0; i <= N; i++)
            {
                t[i] = a + i * h;
            }
            string tableString = StringUtil.BuildTable(new string[] { "t", "y(t)", "y'(t)" }, t, shootingResult);
            string fileName = "VanderPol.txt";
            File.WriteAllText(fileName, tableString);

            Console.WriteLine("Done !! Results Written to " + fileName);

        }

        private static double f(double x, double y1, double y2)
        {
            return 0.5 * y2 * (y1 * y1 - 1) - y1; 
        }

        private static double fy(double x, double y1, double y2)
        {
            return y1 * y2 - 1;
        }

        private static double fyp(double x, double y1, double y2)
        {
            return 0.5 * y1 * y1 - 0.5;
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
