using System;

namespace practice12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите N:");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) && N <= 0)
                Console.WriteLine("error! Введите целое положительное число");

            Random rnd = new Random();
            int[] array = new int[N];
            int[] array2 = new int[N];
            for (int i = 0; i < N; i++)
            {
                array[i] = rnd.Next(-100, 101);
                array2[i] = array[i];
            }

            Console.WriteLine("Сравнение сортировки неупорядоченного массива");
            Console.WriteLine("Исходный массив:");
            PrintArray(array);
            Console.WriteLine();
            PrintArray(SortByChoice(array));
            Console.WriteLine();
            PyramidalSorting(array2);

            Console.WriteLine();
            Console.WriteLine("Сравнение сортировки упорядоченного по возрастанию массива");
            Console.WriteLine("Исходный массив:");
            PrintArray(array);
            Console.WriteLine();
            PrintArray(SortByChoice(array));
            Console.WriteLine();
            PyramidalSorting(array2);

            Console.WriteLine();
            Console.WriteLine("Сравнение сортировки упорядоченного по убыванию массива");
            Console.WriteLine("Исходный массив:");
            PrintArray(TurnArray(array));
            Console.WriteLine();
            PrintArray(SortByChoice(array));
            Console.WriteLine();
            PyramidalSorting(TurnArray(array2));
        }

        static int[] SortByChoice(int[] mas)
        {
            int exchanges = 0;
            int comparisons = 0;

            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    comparisons++;
                    if (mas[j] < mas[min])
                        min = j;
                }

                //обмен элементов
                if (min != i)
                {
                    exchanges++;
                    int temp = mas[min];
                    mas[min] = mas[i];
                    mas[i] = temp;
                }
            }

            Console.WriteLine("Сортировка вростым выбором");
            Console.WriteLine("Количество сравнений - " + comparisons);
            Console.WriteLine("Количество пересылок - " + exchanges);
            Console.WriteLine("Полученный массив:");
            return mas;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static int[] TurnArray(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }

            return arr;
        }

        static int[] MakeSortedTree(int[] mas, int maxElem, int elem, ref int compare, ref int changes)
        {
            //функция, строящая сортировочное дерево

            int maxDescendant = elem; //индекс максимального из двух потомков данного элемента

            int LeftDescendant = elem * 2 + 1; //индекс левого потомка данного элемента

            int RightDescendant = elem * 2 + 2; //индекс правого потомка данного элемента

            while (LeftDescendant < maxElem) //пока не дойдем до границы неотсортированной части массива
            {
                compare++;
                if (RightDescendant >= maxElem
                ) //если мы дошли до последнего элемента в неотсортированной части и правый потомок уже в отсортированной части
                {
                    maxDescendant = LeftDescendant;
                }
                else //если мы еще не дошли до конца неотсортированной части и правый потомок тоже находится в ней
                if (mas[LeftDescendant] > mas[RightDescendant]
                ) //находим максимальный элемент и  записываем его индекс в maxDescendant
                {
                    maxDescendant = LeftDescendant;
                    compare++;
                }
                else
                {
                    maxDescendant = RightDescendant;
                    compare++;
                }

                compare++;
                if (mas[maxDescendant] <= mas[elem]
                ) //если потомок не больше данного элемента, то заканчивам построение сортировочного дерева
                {
                    compare++;
                    break;
                }
                else //если потомок больше данного элемента, то меняем их местами
                {
                    int k = mas[elem]; //вспомогательна переменная
                    mas[elem] = mas[maxDescendant];
                    mas[maxDescendant] = k;
                    changes++;
                    elem = maxDescendant; //данный элемент меняет индекс
                    LeftDescendant = elem * 2 + 1; //индекс левого потомка данного элемента
                    RightDescendant = elem * 2 + 2; //индекс правого потомка данного элемента
                }

                compare++;
            }

            compare++;
            return mas;
        }

        static void PyramidalSorting(int[] mas)
        {
            //функция, в которой выполняется два этапа пирамидальной сортировки
            int changes = 0;
            int compare = 0;
            //первый этап: составляем пирамиду, прогоняя по не ней элементы, имеющие потомков, начиная с самого нижнего

            for (int i = mas.Length / 2 - 1; i >= 0; i--)
            {
                compare++;
                mas = MakeSortedTree(mas, mas.Length, i, ref compare,
                    ref changes); //нижней границы пока нет, так как массив еще не начали сортировать               
            }

            compare++;
            //второй этап: меняем местами первый и последний в неотсортированной части, затем прогоняем новый верхний элемент, составляя пирамиду
            for (int i = mas.Length - 1; i >= 1; i--)
            {
                compare++;
                //меняем местами верхний и нижний элементы неотсортированной части (последний элемент - новый край отсортированной части)
                int k = mas[i];
                mas[i] = mas[0];
                mas[0] = k;
                changes++;
                //составляем пирамиду, передвинув нижний край на один влево. Прогоняем по ней верхний элемент
                mas = MakeSortedTree(mas, i, 0, ref compare, ref changes);
            }

            compare++;
            Console.WriteLine("Пирамидальная сортировка:");
            Console.WriteLine("Количество сравнений: " + compare);
            Console.WriteLine("Количество пересылок: " + changes);
            Console.WriteLine("Полученный массив:");
            PrintArray(mas);
        }
    }
}