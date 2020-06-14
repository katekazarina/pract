using System;
using System.Collections.Generic;

namespace practice6
{
    internal class Program
    {
        private static List<double> an = new List<double>();

        public static void Main(string[] args)
        {
            double a1 = DParse("Введите a1:");
            double a2 = DParse("Введите a2:");
            double a3 = DParse("Введите a3:");
            double M = DParse("Введите M:");
            int N = IParse("Введите N:");

            an.Add(a1);
            an.Add(a2);
            an.Add(a3);

            Sequence(a3, a2, a1, N, M);

            Console.WriteLine(
                an.Count == N ? "Остановка! последовательность содержит N элементов" : "Остановка! ak > M");
            ShowList();
        }

        private static void Sequence(double ak1, double ak2, double ak3, int N, double M)
        {
            double ak = ak2 / ak1 + Math.Abs(ak3);
            an.Add(ak);

            if (an.Count == N || ak > M)
                return;
            else Sequence(ak, ak1, ak2, N, M);
        }
        
        private static double DParse(string s)
        {
            Console.WriteLine(s);
            double x;
            while (!double.TryParse(Console.ReadLine(), out x))
                Console.WriteLine("error! Введите действительное число");

            return x;
        }

        private static int IParse(string s)
        {
            Console.WriteLine(s);
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x <= 3)
                Console.WriteLine("error! Введите целое число больше 3");

            return x;
        }

        private static void ShowList()
        {
            Console.WriteLine("Полученная последовательность:");
            foreach (double item in an)
                Console.Write($"{item:0.00}" + " ");
        }
    }
}