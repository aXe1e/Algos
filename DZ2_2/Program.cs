using System;

namespace DZ2_2
{
    class Program
    {
        //Сложность алгоритма = logN
        public static int BinarySearch(int[] inputArray, int searchValue) 
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
