using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DZ3
{
    class Program
    {
        private static Random rnd = new Random();
        public static int ArrMaxElem = 100;

        public static PointClass[] ArrClassFloatOne = new PointClass[ArrMaxElem];
        public static PointClass[] ArrClassFloatTwo = new PointClass[ArrMaxElem];
        
        public static PointStruct<float>[] ArrStructFloatOne = new PointStruct<float>[ArrMaxElem];
        public static PointStruct<float>[] ArrStructFloatTwo = new PointStruct<float>[ArrMaxElem];

        public static PointStruct<double>[] ArrStructDoubleOne = new PointStruct<double>[ArrMaxElem];
        public static PointStruct<double>[] ArrStructDoubleTwo = new PointStruct<double>[ArrMaxElem];

        public static void Init()
        {
            for (int i = 0; i < ArrMaxElem; i++)
            {
                var ClassFloatOne = new PointClass { X = (float)rnd.NextDouble() * ArrMaxElem, Y = (float)rnd.NextDouble() * ArrMaxElem };
                var ClassFloatTwo = new PointClass { X = (float)rnd.NextDouble() * ArrMaxElem, Y = (float)rnd.NextDouble() * ArrMaxElem };

                ArrClassFloatOne[i] = ClassFloatOne;
                ArrClassFloatTwo[i] = ClassFloatTwo;
                
                ArrStructFloatOne[i].X = (float)rnd.NextDouble() * ArrMaxElem;
                ArrStructFloatOne[i].Y = (float)rnd.NextDouble() * ArrMaxElem;
                ArrStructFloatTwo[i].X = (float)rnd.NextDouble() * ArrMaxElem;
                ArrStructFloatTwo[i].Y = (float)rnd.NextDouble() * ArrMaxElem;
                ArrStructDoubleOne[i].X = rnd.NextDouble() * ArrMaxElem;
                ArrStructDoubleOne[i].Y = rnd.NextDouble() * ArrMaxElem;
                ArrStructDoubleTwo[i].X = rnd.NextDouble() * ArrMaxElem;
                ArrStructDoubleTwo[i].Y = rnd.NextDouble() * ArrMaxElem;
            }
        }
        static void Main(string[] args)
        {
            Init();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        
        [Benchmark]
        public void TestPDistClassFloat()
        {
            for (int i = 0; i < Program.ArrMaxElem; i++)
            {
                CalcDist.PDistClassFloat(Program.ArrClassFloatOne[i], Program.ArrClassFloatTwo[i]);
            }
            
        }

        [Benchmark]
        public void TestPDistStructFloat()
        {
            for (int i = 0; i < Program.ArrMaxElem; i++)
            {
                CalcDist.PDistStructFloat(Program.ArrStructFloatOne[i], Program.ArrStructFloatTwo[i]);
            }
        }
        
        [Benchmark]
        public void TestPDistStructDouble()
        {
            for (int i = 0; i < Program.ArrMaxElem; i++)
            {
                CalcDist.PDistStructDouble(Program.ArrStructDoubleOne[i], Program.ArrStructDoubleTwo[i]);
            }
        }

        [Benchmark]
        public void TestSimplePDistStructFloat()
        {
            for (int i = 0; i < Program.ArrMaxElem; i++)
            {
                CalcDist.SimplePDistStructFloat(Program.ArrStructFloatOne[i], Program.ArrStructFloatTwo[i]);
            }
        }
    }

}
