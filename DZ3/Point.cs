using System;
using System.Collections.Generic;
using System.Text;

namespace DZ3
{
    public class PointClass
    {
        public float X { get; set; }
        public float Y { get; set; }

    }
    public struct PointStruct<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
    }   
}
