using System;

namespace practice3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double x = DParse("Введите координату x:");
            double y = DParse("Введите координату y:");

            if (x >= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) <= 1 || y <= x / 2 + 1 && y >= -x / 2 - 1 && x<0)
                Console.WriteLine("Точка принадлежит области");
            else Console.WriteLine("Точка не принадлежит области");
        }

        private static double DParse(string s)
        {
            Console.WriteLine(s);
            double num;
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Ошибка ввода! Введите действительное число");
            }

            return num;
        }
    }
}