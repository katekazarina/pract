using System;

namespace practice1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            int N = int.Parse(Console.ReadLine());
            double[,] P = new double[N, 2];
            for (int i = 0; i < N; i++)
            {
                string[] tmp = Console.ReadLine().Split(' ');
                for (int j = 0; j < 2; j++)
                    P[i, j] = int.Parse(tmp[j]);
            }

            int K = int.Parse(Console.ReadLine());

            Dual(P, K, N);
        }

        private static void Dual(double[,] P, int K, int N)
        {
            if (K != 0)
            {
                double[,] tmp = new double[P.Length / 2, 2];
                for (int i = 0; i < N; i++)
                {
                    if (i == N - 1)
                    {
                        tmp[i, 0] = (P[i, 0] + P[0, 0]) / 2;
                        tmp[i, 1] = (P[i, 1] + P[0, 1]) / 2;
                    }
                    else
                    {
                        tmp[i, 0] = (P[i, 0] + P[i + 1, 0]) / 2;
                        tmp[i, 1] = (P[i, 1] + P[i + 1, 1]) / 2;
                    }
                }

                P = tmp;
                Dual(P, K - 1, N);
                return;
            }

            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                    sum += Math.Sqrt(Math.Pow(P[i, 0] - P[N - 1, 0], 2) + Math.Pow(P[i, 1] - P[N - 1, 1], 2));
                else sum += Math.Sqrt(Math.Pow(P[i, 0] - P[i - 1, 0], 2) + Math.Pow(P[i, 1] - P[i - 1, 1], 2));
            }

            Console.WriteLine(sum);
        }
    }
}