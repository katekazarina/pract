using System;
using System.Collections.Generic;

namespace practice5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int size; //n
            Console.WriteLine("Введите размер матрицы:");
            while (!int.TryParse(Console.ReadLine(), out size) && size <= 0)
                Console.WriteLine("error! Введите целое положительное число");
            
            int[,] matrix = new int[size, size];
            Console.WriteLine("Введите матрицу:");
            for (int i = 0; i < size; i++)
            {
                int[] tmp = SParse(size).ToArray();
                for (int j = 0; j < size; j++)
                    matrix[i, j] = tmp[j];
            }

            List<int> strs = new List<int>();

            for (int i = 0; i < size; i++)
            {
                bool ok = true;
                for (int j = 0; j < size / 2; j++)
                {
                    if (matrix[i, j] != matrix[i, size - j - 1])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                    strs.Add(i + 1);
            }

            if (strs.Count == 0)
                Console.WriteLine("Матрица не содержит строк-палиндромов");
            else
            {
                Console.WriteLine("Номера строк-палиндромов матрицы: ");
                foreach (int item in strs)
                    Console.Write(item + " ");
            }
        }

        private static List<int> SParse(int size)
        {
            bool ok = true;
            List<int> str;
            do
            {
                str = new List<int>();
                string[] tmp = Console.ReadLine().Split(' ');

                if (tmp.Length < size)
                {
                    Console.WriteLine("error! Длина строки должна быть = " + size);
                    ok = false;
                }
                else
                {
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (int.TryParse(tmp[i], out int x))
                        {
                            ok = true;
                            str.Add(x);
                        }
                        else
                        {
                            Console.WriteLine("error! Матрица должна быть целочисленной");
                            ok = false;
                            break;
                        }
                    }
                }
            } while (!ok);

            return str;
        }
    }
}