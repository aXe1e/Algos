using System;

namespace DZ1_1
{
    class Program
    {
        //1. Напишите на C# функцию согласно блок-схеме
        public class TestCase
        {
            public int N { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        //Метод определения простых чисел
        static string SimpleNumber(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Число должно быть положительным!");
            }
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }

            string s;
            if (d == 0)
            {
                s = "Простое";
            }
            else
            {
                s = "Не простое";
            }
            Console.WriteLine(s);
            return s;
        }

        static void TestSimpleNumber(TestCase tstCase)
        {
            try
            {
                var actual = SimpleNumber(tstCase.N);

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
                N = 6,
                Expected = "Не простое",
                ExpectedException = null
            };

            var testCase2 = new TestCase()
            {
                N = 139,
                Expected = "Простое",
                ExpectedException = null
            };

            var testCase3 = new TestCase()
            {
                N = -42,
                Expected = "Не простое",
                ExpectedException = new ArgumentException("Число должно быть положительным!")
            };

            Console.WriteLine("Тесты определению простого числа:");
            TestSimpleNumber(testCase1);
            TestSimpleNumber(testCase2);
            TestSimpleNumber(testCase3);
        }
    }
}
