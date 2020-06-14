using System;

namespace practice4
{
    internal class Program
    {
        private static double eps;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите точность e");
            while (!double.TryParse(Console.ReadLine(), out eps))
                Console.WriteLine("error! Введите действительное число");
            
            double x1 = 3.7;
            double x2 = 5;

            if (CheckValue(Function(x1)) || CheckValue(Function(x2)))
                return;
            
            double dx = x2 - x1;
            double middle = (x1 + x2) / 2;
            while (Math.Abs(Function(middle)) > eps)
            {
                dx/=2;
                middle = x1 + dx;
                if (Math.Sign(Function(x1)) == Math.Sign(Function(middle)))
                    x1 = middle;
            }
            Console.WriteLine("Приближенное значение корня уравнения - " + middle);
        }

        private static bool CheckValue(double value)
        {
            if (Math.Abs(Function(value)) < eps)
            {
                Console.WriteLine("Приближенное значение корня уравнения - " + value);
                return true;
            }
            return false;
        }

        private static double Function(double x)
        {
            return Math.Pow(x, 4)-4.1*Math.Pow(x, 3)+Math.Pow(x, 2)-5.1*x + 4.1;
        }
    }
}