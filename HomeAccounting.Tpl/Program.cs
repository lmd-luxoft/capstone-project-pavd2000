using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeAccounting.Tpl
{
    class Program
    {
        public const int mtMax = 4;
        static void Main(string[] args)
        {
            var array1 = GenerateArray(1000); // new[] { 1, 9, 2, 8, 3, 7, 5, 6, 10, 20, 11, 19, 12, 18, 13, 17, 14, 16, 15 };  //;
            var array2 = new int[array1.Length];
             Array.Copy(array1, array2, array1.Length);

            MergeSortArray(array1);
            MergeSortArrayMT(array2);
            //QuadraticEquation();
            Console.WriteLine("Press any key to exit the process...");
            Console.ReadKey();
        }

        

        public static void MergeSortArrayMT(int[] array)
        {
            var initialDate = DateTime.Now;
            Console.WriteLine($"start MergeSortArrayMT. array length: {array.Length}. max tasks: {mtMax}");
            //var array = GenerateArray(100);///new[] { 1, 9, 2, 8, 3, 7, 5, 6, 10, 20, 11, 19, 12, 18, 13, 17, 14, 16, 15 };
           // Console.WriteLine($"initial array: {string.Join(", ", array)}");
            var resultingArray = MergeSortMT(array);
            var finalDate = DateTime.Now;
            //Console.WriteLine($"sorted array: { string.Join(", ", resultingArray)}");
            Console.WriteLine($"Run tyme (millisec): {(finalDate - initialDate).TotalMilliseconds}");
        }

        public static int[] GenerateArray(int n)
        {
            var rnd = new Random();
            var res = new int[n];

            for(var i = 0; i < n; i++)
            {
                res[i] = rnd.Next();
            }
            return res;
        }

        public static void MergeSortArray(int[] array)
        {
            var initialDate = DateTime.Now;
            Console.WriteLine($"start MergeSortArray. array length: {array.Length}");
           // var array = new[] { 1, 9, 2, 8, 3, 7, 5, 6, 10, 20, 11, 19, 12, 18, 13, 17, 14, 16, 15 };
            //Console.WriteLine($"initial array: {string.Join(", ", array)}");
            var resultingArray = MergeSort(array);
            var finalDate = DateTime.Now;
            //Console.WriteLine($"sorted array: { string.Join(", ", resultingArray)}");
            Console.WriteLine($"Run tyme (millisec): {(finalDate - initialDate).TotalMilliseconds}");

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
            if (tmp < 0)
            {
                throw new InvalidOperationException("Нет решений");
            }

            return Math.Sqrt(part1 * part1 - part2);
        }

        public static double Part4(double part1, double part3)
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

        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        private static int mtCount = 0;

        //сортировка слиянием многопоточная
        static int[] MergeSortMT(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;

                if (mtCount < mtMax)
                {
                    var t1 = new Task(() => { MergeSortMT(array, lowIndex, middleIndex); });
                    var t2 = new Task(() => { MergeSortMT(array, middleIndex + 1, highIndex); });

                    t1.Start();
                    Interlocked.Increment(ref mtCount);
                    t2.Start();
                    Interlocked.Increment(ref mtCount);
                    var t3 = Task.WhenAll(t1, t2);
                    t3.Wait();
                    Interlocked.Decrement(ref mtCount);
                    Interlocked.Decrement(ref mtCount);
                }
                else
                {
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                }

                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }


        static int[] MergeSortMT(int[] array)
        {
            return MergeSortMT(array, 0, array.Length - 1);
        }


    }
}
