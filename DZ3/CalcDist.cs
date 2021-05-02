using System;
using System.Collections.Generic;
using System.Text;

namespace DZ3
{
    class CalcDist
    {
        //Метод определения дистанции для класса (тип данных float)
        public static float PDistClassFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        //Метод определения дистанции для структуры (тип данных float)
        public static float PDistStructFloat(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        //Метод определения дистанции для структуры (тип данных double)
        public static double PDistStructDouble(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((float)((x * x) + (y * y)));
        }
        //Упрощенный метод определения дистанции (без квадратного корня) для структуры (тип данных float)
        public static float SimplePDistStructFloat(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}
