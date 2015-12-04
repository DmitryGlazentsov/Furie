using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class myClass
    {
        const int N = 20; // количество разбиений
        public double[] InnerArray_A = new double[N];  //входные значения Амплитуды
        public double[] InnerArray_T = new double[N];   //входные значения времени
        
        public Complex[] Furie = new Complex[N];
        public List<Complex> output = new List<Complex>();
        public int Nn
        {
            get { return N; }
        }


        public void DPF(double[] Inner_A, double[] Inner_T)
        {
            int N = Inner_A.Length; //длинна масива входных данных (беру по амплитуде потому что без разницы по чему брать, по амплитуде или времени)
            double Arg;
            double dt;
            double temp;
            double[] temp2 = new double[20]; 
            double[] f = new double[6];

                for (int k = 0; k < N; k++)
                {
                    Furie[k] = new Complex();
                    Complex t = new Complex();
   
                    for (int n = 0; n < N; n++)
                    {
                        Arg = 2 * Math.PI * k * n / N; //+

                        Furie[k].Re += Inner_A[n] * Math.Cos(Arg);
                        Furie[k].Im -= Inner_A[n] * Math.Sin(Arg);

                        t.Re += Inner_A[n] * Math.Cos(Arg);
                        t.Im -= Inner_A[n] * Math.Sin(Arg);
                    }

                    Furie[k].Amplitude = (Math.Sqrt(Math.Pow(Furie[k].Re, 2) + Math.Pow(Furie[k].Im, 2))) / N;
                    Furie[k].Faza = Math.Atan(Furie[k].Im / Furie[k].Re) / Math.PI * 180;

                    Furie[k].Freq = ((N - 1) * (k));

                    t.Amplitude = (Math.Sqrt(Math.Pow(t.Re, 2) + Math.Pow(t.Im, 2)));
                    t.Faza = Math.Atan2(t.Im, t.Re) / Math.PI * 180;
                    t.Freq = (N - 1) * k;

                    output.Add(t);
                }
        }
    }
   public class Complex
    {
        public double Re;// Реальная часть
        public double Im; // Мнимая
        public double Amplitude; // Амплитуда для АЧХ
        public double Faza; // Фаза для ФЧХ
        public double Freq; // Частота гармоники
    }
    
}
