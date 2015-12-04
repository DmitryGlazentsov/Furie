using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PD
    {
        private static double _A = 10;
        private static double _d = 4 * Math.Pow(10, -6);
        private static double _dh = _d / 2;
        private static double _T = 5 * Math.Pow(10, -6);
        private static double _dt = 4.974 * Math.Pow(10, -8);
        private static int _TCount = 5;
        private static int _N = (int)(_T / _dt);
        private static int _razr = 4;
 
        public static double A { get { return _A; } set { _A = value; } }
        public static double df { get { return _d; } set { _d = value; _dh = value / 2; } }
        public static double dh { get { return _dh; } }
        public static double T { get { return _T; } set { _T = value; } }
        public static double dt { get { return _dt; } set { _dt = value; _N = (int)(_T / _dt); } }
        public static int TCount { get { return _TCount; } set { _TCount = value; } }
        public static int N { get { return _N; } set { _N = value; _dt = _T / _N; } }
        public static int Razr { get { return _razr; } set { _razr = value; } }
 
        public static double f(double t)
        {
            double x = t % T;
            x = x - dh;
            return Math.Abs(x) >= dh ? 0 : A * (1 - (Math.Abs(x) / dh));
        }
 
        public static int kf(double t)
        {
            int r = (int)Math.Pow(2, Razr);
            double ft = f(t);
            for (int i = 0; i < r; i++)
            {
                if (ft >= i && ft <= i+1)
                    return i;
            }
            return r;
        }
 
        public static List<Complex> ToFourier(List<double> input)
        {
            double arg;
            List<Complex> output = new List<Complex>();
            for (int i = 0; i < N; i++)
            {
                Complex t = new Complex();
                for (int n = 0; n < N; n++)
                {
                    arg = 2 * Math.PI * i * n / N;
                    t.Re += input[n] * Math.Cos(arg);
                    t.Im -= input[n] * Math.Sin(arg);
                }
                t.Amplitude = (Math.Sqrt(Math.Pow(t.Re, 2) + Math.Pow(t.Im, 2)));
                t.Faza = Math.Atan2(t.Im, t.Re) / Math.PI * 180;
                t.Freq = (N - 1) * i;
                output.Add(t);
            }
            return output;
        }

        public List<double> FromFourier(List<Complex> input, int N)
        {
            double arg;
            List<double> output = new List<double>();
            for (int i = 0; i < N; i++)
            {
                Complex t = new Complex();
                for (int n = 0; n < N; n++)
                {
                    arg = 2 * Math.PI * i * n / N;
                    double a = input[n].Re, b = input[n].Im, c = Math.Cos(arg), d = Math.Sin(arg);
                    t.Re += a * c - b * d;
                    t.Im += a * d + b * c;
                }
                t.Amplitude = (Math.Sqrt(Math.Pow(t.Re, 2) + Math.Pow(t.Im, 2)))/N;
                t.Faza = Math.Atan2(t.Im, t.Re) / Math.PI * 180;
                t.Freq = (N - 1) * i;
                output.Add(t.Amplitude);
            }
            return output;
        }
 
    }
 
    
    

}
