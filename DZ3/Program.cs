using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DZ3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();            
        }
    }
    public class BenchmarkClass
    {
        private Random rnd = new Random();
        private static int ArrMaxElem = 100;

        private PointClass[] ArrClassFloatOne = new PointClass[ArrMaxElem];
        private PointClass[] ArrClassFloatTwo = new PointClass[ArrMaxElem];

        private PointStruct<float>[] ArrStructFloatOne = new PointStruct<float>[ArrMaxElem];
        private PointStruct<float>[] ArrStructFloatTwo = new PointStruct<float>[ArrMaxElem];

        private PointStruct<double>[] ArrStructDoubleOne = new PointStruct<double>[ArrMaxElem];
        private PointStruct<double>[] ArrStructDoubleTwo = new PointStruct<double>[ArrMaxElem];

        public BenchmarkClass()
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

        //Тест метода определения дистанции для класса (тип данных float)
        [Benchmark]
        public void TestPDistClassFloat()
        {
            float x;
            float y;
            float result;
            for (int i = 0; i < ArrMaxElem; i++)
            {
                x = ArrClassFloatOne[i].X - ArrClassFloatTwo[i].X;
                y = ArrClassFloatOne[i].Y - ArrClassFloatTwo[i].Y;
                result = MathF.Sqrt((x * x) + (y * y));
            }
            
        }

        //Тест метода определения дистанции для структуры (тип данных float)
        [Benchmark]
        public void TestPDistStructFloat()
        {
            float x;
            float y;
            float result;
            for (int i = 0; i < ArrMaxElem; i++)
            {
                x = ArrStructFloatOne[i].X - ArrStructFloatTwo[i].X;
                y = ArrStructFloatOne[i].Y - ArrStructFloatTwo[i].Y;
                result = MathF.Sqrt((x * x) + (y * y));
            }
        }

        //Тест метода определения дистанции для структуры (тип данных double)
        [Benchmark]
        public void TestPDistStructDouble()
        {
            double x;
            double y;
            double result;
            for (int i = 0; i < ArrMaxElem; i++)
            {
                x = ArrStructDoubleOne[i].X - ArrStructDoubleTwo[i].X;
                y = ArrStructDoubleOne[i].Y - ArrStructDoubleTwo[i].Y;
                result = MathF.Sqrt((float)((x * x) + (y * y)));
            }
        }

        //Тест упрощенного метода определения дистанции (без квадратного корня) для структуры (тип данных float)
        [Benchmark]
        public void TestSimplePDistStructFloat()
        {
            float x;
            float y;
            float result;
            for (int i = 0; i < ArrMaxElem; i++)
            {
                x = ArrStructFloatOne[i].X - ArrStructFloatTwo[i].X;
                y = ArrStructFloatOne[i].Y - ArrStructFloatTwo[i].Y;
                result = (x * x) + (y * y);
            }
        }
    }

}
