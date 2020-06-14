using System;

namespace practice10
{
    internal class Program
    {
        private static int N;

        public static void Main(string[] args)
        {
            N = IParse("Введите N:");
            int M = IParse("Введите M:");

            Person.MakeRange(N);
            Console.WriteLine("Номер последнего человека - {0}", Person.DeleteM(M).Num);
        }

        class Person
        {
            public int Num;
            private Person Next;
            private static Person First;

            public Person(int num)
            {
                Num = num;
                Next = null;
            }

            public static void MakeRange(int n)
            {
                First = new Person(1);
                Person tmp = First;
                for (int i = 2; i <= n; i++)
                {
                    tmp.Next = new Person(i);
                    tmp = tmp.Next;
                    if (i == n)
                        tmp.Next = First;
                }
            }

            public static void Delete(Person p)
            {
                Person tmp = First;
                if (First == p)
                {
                    First = tmp.Next;
                    for (int i = 1; i < N; i++)
                        tmp = tmp.Next;
                    tmp.Next = First;
                    return;
                }

                for (int i = 1; i < N; i++)
                {
                    if (tmp.Next == p)
                        break;
                    tmp = tmp.Next;
                }

                tmp.Next = tmp.Next.Next;
            }

            public static Person DeleteM(int m)
            {
                Person person = First;

                if (m == 1)
                {
                    while (person.Next != First)
                    {
                        person = person.Next;
                    }

                    First = person;
                    First.Next = person;
                    return person;
                }

                for (int i = 1; i < m; i++)
                {
                    if (i == m - 1)
                    {
                        i = 0;
                        Delete(person.Next);
                        N--;
                        if (N == 1) return person;
                    }

                    person = person.Next;
                }

                return null;
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
    }
}