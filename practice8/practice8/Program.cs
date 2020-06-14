using System;
using System.Collections.Generic;
using System.Threading;

namespace practice8
{
    internal class Program
    {
        private static int Col; //кол-во ребер (столбцов)
        private static int Row; //кол-во вершин (строк)
        private static List<List<int>> Array; //матрица инцидентности
        private static List<List<int>> NewArray = new List<List<int>>(); //матрица 
        private static List<int> Round = new List<int>();

        public static void Main(string[] args)
        {
            Row = IParse("Введите кол-во вершин (строк)");
            Col = IParse("Введите кол-во ребер (столбцов)");
            while (Col>Row*(Row-1)/2)
            {
                Console.WriteLine("Кол-во ребер должно быть меньше или равно " + Row*(Row-1)/2);
                Row = IParse("Введите кол-во вершин (строк)");
                Col = IParse("Введите кол-во ребер (столбцов)");
            }
            CreateArray();
            Console.WriteLine("Матрица инцидентности");
            ShowArray(Array, Row, Col);

            ToNewArray();
            DeleteRow();

            if (NewArray.Count == 0)
            {
                Console.WriteLine("Матрица не содержит ни один эйлеров цикл");
                return;
            }

            Round.Add(NewArray[0][0]);
            Round.Add(NewArray[0][1]);
            
            NewArray.RemoveAt(0);
            
            for (int i = 0; i < NewArray.Count; i++)
            {
                if (NewArray[i][0] == Round[Round.Count - 1])
                {
                    Round.Add(NewArray[i][1]);
                    NewArray.RemoveAt(i);
                    i = 0;
                }
                else if (NewArray[i][1] == Round[Round.Count - 1])
                {
                    Round.Add(NewArray[i][0]);
                    NewArray.RemoveAt(i);
                    i = 0;
                }
            }
            
            Console.WriteLine("Эйлеров цикл: ");
            foreach (int x in Round)
                Console.Write(x + " ");
            Console.Write(Round[0]);
        }

        private static void ShowArray(List<List<int>> ar, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(ar[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void ToNewArray()
        {
            for (int j = 0; j < Col; j++)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < Row; i++)
                {
                    if (Array[i][j] == 1)
                    {
                        tmp.Add(i + 1);
                    }
                }

                NewArray.Add(tmp);
            }
        }

        private static void DeleteRow()
        {
            bool wasDeleted = false;
            int col = NewArray.Count;
            for (int i = 1; i <= Row; i++)
            {
                int x = 0;
                int rowForDel = 0;
                for (int j = 0; j < col; j++)
                {
                    if (NewArray[j][1] == i || NewArray[j][0] == i)
                    {
                        x++;
                        rowForDel = j;
                    }
                }

                if (x == 1)
                {
                    NewArray.RemoveAt(rowForDel);
                    col--;
                    wasDeleted = true;
                }
            }

            if (wasDeleted && NewArray.Count>0)
                DeleteRow();
        }

        static int IParse(string s)
        {
            Console.WriteLine(s);
            int x;
            while (!int.TryParse(Console.ReadLine(), out x) || x <= 0)
            {
                Console.WriteLine("error! Введите целое положительное число");
            }

            return x;
        }

        static void CreateArray()
        {
            do
            {
                Array = new List<List<int>>();
                for (int i = 0; i < Row; i++) //заполнение матрицы нулями
                {
                    Array.Add(new List<int>());
                    for (int j = 0; j < Col; j++)
                        Array[i].Add(0);
                }
                
                Random rnd = new Random();
                for (int i = 0; i < Col; i++)
                {
                    int j = rnd.Next(0, Row);
                    Array[j][i] = 1;
                    Thread.Sleep(50);
                    bool ok = false;
                    do
                    {
                        j = rnd.Next(0, Row);
                        if (Array[j][i] == 1) continue;
                        ok = true;
                        Array[j][i] = 1;
                    } while (!ok);
                }
            } while (!CheckArray());
        }

        static bool CheckArray()
        {
            for (int i = 0; i < Row; i++) //проверка по строкам: единиц должно быть меньше кол-ва вершин
            {
                int count=0;
                for (int j=0; j<Col; j++)
                    if (Array[i][j] == 1)
                        count++;
                if (count >= Row)
                    return false;
            }
            
            for (int i = 0; i < Col; i++)
            {
                bool ok = true;
                for (int j = i + 1; j < Col; j++)
                {
                    for (int k =0; k<Row; k++)
                        if (Array[k][i] == Array[k][j])
                            ok = true;
                        else
                        {
                            ok = false;
                            break;
                        }

                    if (ok) return false;
                }
            }
            
            return true;
        }
    }
}