using System;

namespace DZ4_2
{
    class Program
    {
        public class TestCase
        {
            public int[] N { get; set; }
            public int[] Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        //Проверяем добавление и поиск по значению
        static void TestAddItem(TestCase tstCase)
        {
            var t = new Tree();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    t.AddItem(tstCase.N[i]);
                }
                t.PrintTree();

                bool Equals = true;
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    if (t.GetNodeByValue(tstCase.N[i]).Value != tstCase.N[i])
                        Equals = false;
                }

                if (Equals)
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
                t.PrintTree();
            }
        }

        //Проверяем удаление
        static void TestRemoveItem(TestCase tstCase, int ValToRemove)
        {
            var t = new Tree();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    t.AddItem(tstCase.N[i]);
                }

                Console.WriteLine($"Дерево до удаления элемента {ValToRemove}");
                t.PrintTree();
                t.RemoveItem(ValToRemove);
                
                bool Equals = true;
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    if (tstCase.N[i] != ValToRemove)
                    {
                        if (t.GetNodeByValue(tstCase.N[i]).Value != tstCase.N[i])
                            Equals = false;
                    }
                    else
                    if (t.GetNodeByValue(tstCase.N[i]) != null)
                        Equals = false;
                }
                if (Equals)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
                Console.WriteLine($"Дерево после удаления элемента {ValToRemove}");
                t.PrintTree();
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
                t.PrintTree();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Проверяем добавление:");
            var testCase1 = new TestCase() { N = new int[12] { 15, 20, 30, 10, 9, 17, 13, 14, 12, 11, 3, 16 } };
            TestAddItem(testCase1);

            Console.WriteLine("2. Проверяем удаление листа:");
            TestRemoveItem(testCase1, 3);

            Console.WriteLine("3. Проверяем удаление узла:");            
            TestRemoveItem(testCase1, 10);

            Console.WriteLine("4. Проверяем удаление корня:");
            TestRemoveItem(testCase1, 15);
        }
    }
}
