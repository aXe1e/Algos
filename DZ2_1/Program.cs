using System;

namespace DZ2_1
{
    //1. Двусвязный список
    class Program
    {
        public class TestCase
        {
            public int[] N { get; set; }
            public int[] Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        //Проверяем добавление нод
        static void TestAddNode(TestCase tstCase)
        {
            var ll = new LinkedList();
            try
            {
                Console.WriteLine($"Кол-во нод до добавления:{ll.GetCount()}");
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                Console.WriteLine($"Кол-во нод после добавления:{ll.GetCount()}");
                var actual = ll.ToArray();
                bool Equals = true;

                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    if (actual[i] != tstCase.Expected[i])
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
            }
        }
        //Проверяем добавление нод
        static void TestAddNodeAfter(TestCase tstCase)
        {
            var ll = new LinkedList();
            try
            {

                Console.WriteLine($"Кол-во нод до добавления:{ll.GetCount()}");
                for (int i = 0; i < tstCase.N.Length-1; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                var node = ll.FindNode(tstCase.N[0]);
                ll.AddNodeAfter(node, tstCase.N[tstCase.N.Length - 1]);

                Console.WriteLine($"Кол-во нод после добавления:{ll.GetCount()}");
                var actual = ll.ToArray();
                bool Equals = true;

                for (int i = 0; i < tstCase.Expected.Length; i++)
                {
                    if (actual[i] != tstCase.Expected[i])
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
            }
        }
        //Проверяем удаление нод
        static void TestRemoveNodeIndex(TestCase tstCase)
        {
            var ll = new LinkedList();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                Console.WriteLine($"Кол-во нод до удаления:{ll.GetCount()}");
                ll.RemoveNode(1);
                Console.WriteLine($"Кол-во нод после удаления:{ll.GetCount()}");
                
                var actual = ll.ToArray();
                bool Equals = true;

                for (int i = 0; i < tstCase.Expected.Length; i++)
                {
                    if (actual[i] != tstCase.Expected[i])
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
            }
        }
        //Проверяем удаление нод
        static void TestRemoveNode(TestCase tstCase)
        {
            var ll = new LinkedList();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                Console.WriteLine($"Кол-во нод до удаления:{ll.GetCount()}");
                var node = ll.GetByIndex(1);
                ll.RemoveNode(node);
                Console.WriteLine($"Кол-во нод после удаления:{ll.GetCount()}");

                var actual = ll.ToArray();
                bool Equals = true;

                for (int i = 0; i < tstCase.Expected.Length; i++)
                {
                    if (actual[i] != tstCase.Expected[i])
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
            }
        }
        //Проверяем поиск нод по значению
        static void TestFindNode(TestCase tstCase)
        {
            var ll = new LinkedList();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                var node = ll.FindNode(tstCase.Expected[0]);
                                                
                if (node.Value == tstCase.Expected[0])
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

        //Проверяем поиск нод по индексу
        static void TestFindNodeIndex(TestCase tstCase, int index)
        {
            var ll = new LinkedList();
            try
            {
                for (int i = 0; i < tstCase.N.Length; i++)
                {
                    ll.AddNode(tstCase.N[i]);
                }

                var node = ll.GetByIndex(index);

                if (node.Value == tstCase.Expected[0])
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
            Console.WriteLine("Проверяем последовательное добавление нод:");
            var testCase1 = new TestCase() { N = new int[5] { 1, 3, 5, 7, 9 }, Expected = new int[5] { 1, 3, 5, 7, 9 }, ExpectedException = null};
            TestAddNode(testCase1);

            Console.WriteLine("Проверяем добавление нод первой:");
            var testCase2 = new TestCase() { N = new int[6] { 1, 3, 5, 7, 9, 11 }, Expected = new int[6] { 1, 11, 3, 5, 7, 9 }, ExpectedException = null };
            TestAddNodeAfter(testCase2);

            Console.WriteLine("Проверяем удаление нод:");
            var testCase3 = new TestCase() { N = new int[5] { 1, 3, 5, 7, 9 }, Expected = new int[4] { 1, 5, 7, 9 }, ExpectedException = null };
            TestRemoveNodeIndex(testCase3);
            TestRemoveNode(testCase3);

            Console.WriteLine("Проверяем поиск нод:");
            var testCase4 = new TestCase() { N = new int[5] { 1, 3, 5, 7, 9 }, Expected = new int[1] { 5 }, ExpectedException = null };
            TestFindNode(testCase4);
            TestFindNodeIndex(testCase4, 2);

        }
    }
}
