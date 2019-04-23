using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM6004_CA4
{
    class Newton
    {
        static public double[] NonLinearShooting(Func<double, double, double, double> f,
            Func<double, double, double, double> fy, Func<double, double, double, double> fyp,
            double a, double b, double alpha, double beta, int N, int MaxIt, double Tol)
        {
            double h = (b - a) / N;
            double k = 1;
            double tk = (beta - alpha) / (b - a);

            while(k <= MaxIt)
            {
                double w10 = alpha;
                //List<double> w1 = new List<double> { alpha };
                double[] w1 = new double[N + 1];
                w1[0] = alpha;

                double w20 = tk;
                //List<double> w2 = new List<double> { tk };
                double[] w2 = new double[N + 1];
                w2[0] = tk;

                double u1 = 0;
                double u2 = 1;

                for (int i = 1; i <= N; i++)
                {
                    double x = a + (i - 1) * h;
                    double k11 = h * w2[i - 1];
                    double k12 = h * f(x, w1[i - 1], w2[i - 1]);
                    double k21 = h * (w2[i - 1] + k12 / 2);
                    double k22 = h * f(x + h / 2, w1[i - 1] + k11 / 2, w2[i - 1] + k12 / 2);
                    double k31 = h * (w2[i - 1] + k22 / 2);
                    double k32 = h * f(x + h / 2, w1[i - 1] + k21 / 2, w2[i - 1] + k22 / 2);
                    double k41 = h * (w2[i - 1] + k32);
                    double k42 = h * f(x + h, w1[i - 1] + k31, w2[i - 1] + k32);

                    w1[i] = w1[i - 1] + (k11 + 2 * k21 + 2 * k31 + k41) / 6;
                    w2[i] = w2[i - 1] + (k12 + 2 * k22 + 2 * k32 + k42) / 6;

                    double kp11 = h * u2;
                    double kp12 = h * (fy(x, w1[i - 1], w2[i - 1]) * u1 + fyp(x, w1[i - 1], w2[i - 1])*u2);
                    double kp21 = h * (u2 + kp12 / 2);
                    double kp22 = h * (fy(x + h / 2, w1[i - 1], w2[i - 1]) * (u1 + kp11 / 2)
                        +fyp(x + h/2,w1[i-1],w2[i-1]) * (u2 + kp12));

                }
            }

            return new double[] { };
        }
    }
}
