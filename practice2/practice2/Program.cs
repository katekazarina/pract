using System;

namespace practice2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] steps = new int[3];
            string[] tmp = Console.ReadLine().Split(' ');
            int p = 0, d = 0;

            if (n > 1)
            {
                steps[0] = int.Parse(tmp[0]);
                steps[1] = int.Parse(tmp[1]);
                d = Math.Abs(steps[1] - steps[0]);

                for (int i = 2; i < n; i++)
                {
                    steps[2] = int.Parse(tmp[i]);
                    if (Math.Abs(steps[1] - steps[2]) + d < 3 * Math.Abs(steps[0] - steps[2]) + p)
                    {
                        p = d;
                        d += Math.Abs(steps[1] - steps[2]);
                    }
                    else
                    {
                        var t = d;
                        d = 3 * Math.Abs(steps[0] - steps[2]) + p;
                        p = t;
                    }

                    steps[0] = steps[1];
                    steps[1] = steps[2];
                }
            }

            Console.WriteLine(d);
        }
    }
}