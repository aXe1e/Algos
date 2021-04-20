using System;

namespace DZ1_3
{
    //3. Реализуйте функцию вычисления числа Фибоначчи
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        //Метод определения простых чисел
        static int FRecurse(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Число должно быть положительным!");
            }
            return n > 1 ? FRecurse(n - 2) + FRecurse(n - 1) : n;
        }

        static int F(int n)
        {
            if (n > 1)
            {
                int f = 0;
                int f1 = 0;
                int f2 = 1;
                for (int i = 2; i <= n; i++)
                {
                    f = f1 + f2;
                    f1 = f2;
                    f2 = f;
                }
                return f;
            }
            else
                if (n < 0)
            {
                throw new ArgumentException("Число должно быть положительным!");
            }
            else
                return n;
        }

        static void TestFRecurse(TestCase tstCase)
        {
            try
            {
                var actual = FRecurse(tstCase.N);

                if (actual == tstCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception Ex)
            {
                if (tstCase.ExpectedException.HResult == Ex.HResult)
                {
                    Console.WriteLine("EXCEPTION VALID TEST");
                }
                else
                {
                    Console.WriteLine("EXCEPTION INVALID TEST");
                }
            }
        }
        static void TestF(TestCase tstCase)
        {
            try
            {
                var actual = F(tstCase.N);

                if (actual == tstCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception Ex)
            {
                if (tstCase.ExpectedException.HResult == Ex.HResult)
                {
                    Console.WriteLine("EXCEPTION VALID TEST");
                }
                else
                {
                    Console.WriteLine("EXCEPTION INVALID TEST");
                }
            }
        }
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                N = 8,
                Expected = 21,
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                N = 1,
                Expected = 1,
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                N = -10,
                Expected = -10,
                ExpectedException = new ArgumentException("Число должно быть положительным!")
            };

            Console.WriteLine("Тесты по рекурсивному определению числа Фиббоначи:");
            TestFRecurse(testCase1);
            TestFRecurse(testCase2);
            TestFRecurse(testCase3);

            Console.WriteLine("\nТесты по циклическому определению числа Фиббоначи:");
            TestF(testCase1);
            TestF(testCase2);
            TestF(testCase3);
        }
    }
}
