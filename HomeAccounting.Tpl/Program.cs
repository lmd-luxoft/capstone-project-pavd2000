using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeAccounting.Tpl
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticEquation();
            Console.WriteLine("Press any key to exit the process...");
            Console.ReadKey();
        }


        public static double Part1(double a, double b)
        {
            return (b / (2 * a));
        }

        public static double Part2(double a, double c)
        {
            return c / a;
        }

        public static double Part3(double part1, double part2)
        {
            var tmp = part1 * part1 - part2;
            if(tmp < 0)
            {
                throw new InvalidOperationException("Нет решений");
            }

            return Math.Sqrt(part1*part1 - part2);
        }


        public static double Part4(double part1, double part3 )
        {
            return (-1) * part1 + part3;
        }

        public static double Part5(double part1, double part3)
        {
            return (-1) * part1 - part3;
        }

        public static double CheckRes(double a, double b, double c, double x)
        {
            return a * x * x + b * x + c;
        }


        public static void QuadraticEquation()
        {
            // a*x**2 + b*x + c = 0
            
            Console.WriteLine("Start Quadratic Equation ...");

            double a = 4;
            double b = -16;
            double c = 10;

            //double a = 1;
            //double b = 1;
            //double c = 10;

            var t1 = new Task<double>(() => { return Part1(a, b); });
            var t2 = new Task<double>(() => { return Part2(a, c); });
            var t3 = Task.WhenAll(t1, t2).ContinueWith((prev) =>
            {
                var res = prev.Result;
                return Part3(res[0], res[1]);
            });

            var t4 = new Task<double>(() => { return Part4(t1.Result, t3.Result); });
            var t5 = new Task<double>(() => { return Part5(t1.Result, t3.Result); });
            var t6 = Task.WhenAll(t4, t5).ContinueWith((prev) =>
            {
                var res = prev.Result;
                Console.WriteLine($" x1 =  {res[0]}, x2 = {res[1]} ");
                Console.WriteLine($" Check {CheckRes(a, b, c, res[0])}  ");
                Console.WriteLine($" Check2 {CheckRes(a, b, c, res[1])}  ");
            });

            t1.Start();
            t2.Start();
            try
            {
                t3.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine($" {ex.InnerException.Message} ");
                }
                return;
            }

            t4.Start();
            t5.Start();
            t6.Wait();
        }

    }
}
