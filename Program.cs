using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3600;
            int m = 20;
            int a = 0;
            int b = 1;
            Integral11(n, a, b );
            Integral12(n, m,a,b);
            Integral2(1000000);
        }
        public static void Integral12(int n, int m, int a, int b)
        {
            Random rnd = new Random();
            double sum=0;
            double sumSquere = 0;
            double[] averageValueM = new double[m];
            double[] IntegralM = new double[m];
            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    averageValueM[i] += Math.Pow(Math.Exp(1), -rnd.Next((int)(100000*a), (int)(100000 * b))/(100000.0*(b-a)));
                }
                IntegralM[i] = (b - a) * averageValueM[i] / n;
            }
            for (int i = 0; i < m; i++)
            {
                sum += IntegralM[i];
                sumSquere += IntegralM[i] * IntegralM[i];
            }
            double integral = sum / m;
            double sigmaM = Math.Sqrt(sumSquere / m - integral * integral);
            Console.WriteLine("1.2:  Integral: {0} Sigmam: {1} ", integral, Math.Round(sigmaM,8) );
        }
        public static void Integral11(int n,int a, int b)
        {
            Random rnd = new Random();
            double integral=0;
            double avarageValue = 0;
            double sum = 0;
            double sumSquere = 0;
            for (int i = 0; i < n; i++)
            {
                sum += Math.Pow(Math.Exp(1), -rnd.Next((int)(100000 * a), (int)(100000 * b)) / (100000.0 * (b - a)));
                sumSquere += Math.Pow(Math.Pow(Math.Exp(1), -rnd.Next((int)(100000 * a), (int)(100000 * b)) / (100000.0 * (b - a))), 2);
            }
            integral = sum / n;
            double sigma = Math.Sqrt(sumSquere / n - integral * integral);
            double sigmaM = sigma / Math.Sqrt(n);
            double mistake = Math.Abs(-1 / Math.Exp(1) + 1 - integral);
            Console.WriteLine("1.1:  Integral: {0} Sigma: {1} Sigmam: {2} Mistake: {3}", integral, Math.Round(sigma, 8), Math.Round(sigmaM, 8), Math.Round(mistake, 8));
        }
        public static void Integral2(int n)
        {
            Random rnd = new Random();
            double sum = 0;
            double x = 0;
            double integral = 0;
            for (int i=0; i<n; i++)
            {
                x = Math.Log(1 / (1 - rnd.NextDouble()));
                sum += Math.Pow(x, 1.5) * Math.Pow(Math.Exp(-1), x);
            }
            integral = sum / n;
            Console.WriteLine("2: Integral: {0}", integral);
        }
    }
}
