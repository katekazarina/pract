using System;
using System.Collections.Generic;

namespace practice7
{
    internal class Program
    {
        private static List<int> OneSet = new List<int>();
        private static int N;
        private static int K;

        static void Main(string[] args)
        {
            N = IParse("Введите N:");
            K = IParse("Введите K:");

            Console.WriteLine();
            int result = Factorial(N + K - 1) / (Factorial(N - 1) * Factorial(K));
            Console.WriteLine("{0} сочетаний из {1} элементов по {2} с повторениями", result, N, K);
            for (int i = 0; i < K; i++)
            {
                OneSet.Add(1);
                Console.Write(OneSet[i] + " ");
            }
            Console.WriteLine();

            while (MakeSets())
            {
                for (int i = 0; i < K; i++)
                    Console.Write(OneSet[i] + " ");
                Console.WriteLine();
            }
        }

        private static int IParse(string s)
        {
            Console.WriteLine(s);
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x <= 0)
                Console.WriteLine("error! Введите целое положительное число");
            return x;
        }

        private static bool MakeSets()
        {
            int j = K - 1;
            while (j >= 0 && OneSet[j] == N) j--;
            if (j < 0) return false;
            if (OneSet[j] >= N) j--;
            OneSet[j]++;
            if (j == K - 1) return true;
            for (int i = j + 1; i < K; i++)
                OneSet[i] = OneSet[j];
            return true;
        }

        private static int Factorial(int x)
        {
            int fact=1;
            for (int i = 1; i <= x; i++)
                fact *= i;
            return fact;
        }
    }
}