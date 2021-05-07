using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;


namespace DZ4_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();            
        }
        public class BenchmarkClass
        {
            private static int MaxElem = 10000;
            private string[] StrArr;
            private string Result;
            private HashSet<string> hashSet;

            public BenchmarkClass()
            {
                StrArr = new string[MaxElem];
                for (int i = 0; i < MaxElem; i++)
                {
                    StrArr[i] = Guid.NewGuid().ToString();
                }
                hashSet = new HashSet<string>(StrArr);
                Result = StrArr[MaxElem - 1];   //Результат равен последнему элементу архива.
            }

            //Тест метода поиска в HashSet
            [Benchmark]
            public bool TestHashSetSearch()
            {                
                return hashSet.TryGetValue(Result, out var result);
            }

            //Тест метода поиска в архиве
            [Benchmark]
            public bool TestArrSearch()
            {
                for(int i = 0; i < StrArr.Length; i++)
                {
                    if (StrArr[i].Equals(Result))
                        return true;
                }
                return false;
            }
        }
    }
}
