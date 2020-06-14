using System;

namespace practice11
{
    internal class Program
    {
                private static char[][] matrix = new char[11][];
        private static string result = "";

        public static void Main(string[] args)
        {
            //  string str = "Chimes sing Sunday morn todays the day shes sworn"
            //               + " To steal what she never could own an race from this hole she calls home";
            // строка для теста
             Console.WriteLine("Введите текст:");
             string str = Console.ReadLine();
             if (str.Length > 121)
                 str = str.Substring(0, 121);
             if (str.Length < 121)
                 for (int i = str.Length; i < 121; i++)
                     str += " ";
            

            Console.WriteLine("Исходный текст из 121 буквы:");
            Console.WriteLine(str);
            for (int i = 0; i < 11; i++)
                matrix[i] = new char[11];
            Input(5, 5, true, 0, str);
            Console.WriteLine();
            Console.WriteLine("a) Зашифрованный текст");
            PrintMatrix();
            Output(5,5, true, 0);
            Console.WriteLine();
            Console.WriteLine("б) Расшифрованный текст");
            Console.WriteLine(result);
        }

        private static void Input(int x, int y, bool right, int length, string s)
        {
            int iterator = 0;

            if (length == 0)
            {
                matrix[x][y] = s[iterator];
                Input(x + 1, y, right, length + 1, s.Substring(1));
            }
            else if (length == matrix.Length)
            {
                for (int i = 1; i < matrix.Length; i++)
                {
                    matrix[y][i] = s[iterator];
                    iterator++;
                }
            }
            else
            {
                if (right)
                {
                    for (int i = 0; i < length; i++) //вниз
                    {
                        matrix[y][x + i] = s[iterator];
                        iterator++;
                    }

                    for (int i = 0; i < length; i++) //вправо
                    {
                        matrix[y - i - 1][x + length - 1] = s[iterator];
                        iterator++;
                    }

                    Input(x + length - 2, y - length, !right, length + 1, s.Substring(length * 2));
                }
                else if (!right)
                {
                    for (int i = 0; i < length; i++) //вверх
                    {
                        matrix[y][x - i] = s[iterator];
                        iterator++;
                    }

                    for (int i = 0; i < length; i++) //вправо
                    {
                        matrix[y + i + 1][x - length + 1] = s[iterator];
                        iterator++;
                    }

                    Input(x - length + 2, y + length, !right, length + 1, s.Substring(length * 2));
                }
            }
        }

        private static void Output(int x, int y, bool right, int length)
        {
            if (length == 0)
            {
                result += matrix[x][y];
                Output(x + 1, y, right, length + 1);
            }
            else if (length == matrix.Length)
            {
                for (int i = 1; i < matrix.Length; i++)
                    result += matrix[y][i];
            }
            else
            {
                if (right)
                {
                    for (int i = 0; i < length; i++) //вниз
                        result += matrix[y][x + i];


                    for (int i = 0; i < length; i++) //вправо
                        result += matrix[y - i - 1][x + length - 1];


                    Output(x + length - 2, y - length, !right, length + 1);
                }
                else if (!right)
                {
                    for (int i = 0; i < length; i++) //вверх
                        result += matrix[y][x - i];

                    for (int i = 0; i < length; i++) //вправо
                        result += matrix[y + i + 1][x - length + 1];

                    Output(x - length + 2, y + length, !right, length + 1);
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                    Console.Write(matrix[j][i] + " ");
                Console.WriteLine();
            }
        }
    }
}