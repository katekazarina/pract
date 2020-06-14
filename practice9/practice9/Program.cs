using System;

namespace practice9
{
    internal class Program
    {
                public static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Введите кол-во элементов списка");
            while(!int.TryParse(Console.ReadLine(), out size) || size <= 0)
                Console.WriteLine("error! Введите целое положительное число");
            Console.WriteLine("Введите список построчно");
            UnList headList = UnList.MakeList(size);
            headList.ShowList(headList, "Исходный список:");
            ResList Pos = new ResList();
            ResList Neg = new ResList();

            UnList head = headList;
            while (head != null)
            {
                if (head.Item > 0)
                    Pos.Add(head);
                else if (head.Item < 0)
                    Neg.Add(head);
                head = head.Next;
            }
            
            Console.WriteLine();
            Pos.ShowList("Список с положительными значениями: ");

            Console.WriteLine();
            Neg.ShowList("Список с отрицательными значениями: ");
        }
    }

    class UnList
    {
        public int Item { get; set; }
        public UnList Next;

        public UnList()
        {
            int result;
            while(!int.TryParse(Console.ReadLine(), out result))
                Console.WriteLine("error! Введите целое число");
            Item = result;
            Next = null;
        }

        public static UnList MakeItem()
        {
            UnList item = new UnList();
            return item;
        }

        public static UnList MakeList(int length)
        {
            UnList head = MakeItem(); //первый элемент
            UnList first = head;
            for (int i = 1; i < length; i++)
            {
                UnList item = MakeItem();
                head.Next = item;
                head = item;
            }

            return first;
        }

        public void ShowList(UnList head, string s)
        {
            Console.WriteLine(s);
            if (head == null)
            {
                Console.WriteLine("лист пуст");
                return;
            }

            UnList item = head;
            while (item != null)
            {
                Console.Write(item.Item + " ");
                item = item.Next;
            }

            Console.WriteLine();
        }
    }

    class ResList
    {
        private ResList First;
        public UnList Item;
        public ResList Next;

        public ResList()
        {
            First = null;
            Item = null;
            Next = null;
        }

        public ResList(UnList item)
        {
            Item = item;
            Next = null;
        }

        public void Add(UnList last)
        {
            if (First == null)
            {
                First = new ResList(last);
                return;
            }

            ResList item = First;
            while (item.Next != null)
                item = item.Next;
            item.Next = new ResList(last);
        }

        public void ShowList(string s)
        {
            Console.WriteLine(s);
            if (First == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            ResList item = First;
            while (item != null)
            {
                Console.Write(item.Item.Item + " ");
                item = item.Next;
            }

            Console.WriteLine();
        }
    }
}