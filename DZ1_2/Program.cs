using System;

namespace DZ1_2
{
    class Program
    {
        //2. Посчитайте сложность функции
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            // O(1)
            for (int i = 0; i < inputArray.Length; i++)             // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)         // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)     // O(N)
                    {
                        int y = 0;                                  // O(1)

                        if (j != 0)
                        {
                            y = k / j;                              // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;       // O(1)
                    }
                }
            }

            return sum;
        }
        //Сложность функции = O(N) * O(N) * O(N) = O(N^3)
        static void Main(string[] args)
        {
            
        }
    }
}
