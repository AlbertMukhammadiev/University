using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_4_spiral_
{
    class Program
    {
        /// <summary>
        /// displays the array in a spiral
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        private static void Spiral(int[,] matrix, int size)
        {
            var i = size / 2;
            var j = i;
            Console.Write(matrix[i, j] + " ");
            var step = 1;
            var direction = 1;
            while (step < size)
            {
                for (int k = 0; k < step; ++k)
                {
                    j += direction;
                    Console.Write(matrix[i, j] + " ");
                }

                for (int k = 0; k < step; ++k)
                {
                    i += direction;
                    Console.Write(matrix[i, j] + " ");
                }

                direction *= -1;
                ++step;
            }

            for (int k = 0; k < step - 1; ++k)
            {
                j += direction;
                Console.Write(matrix[i, j] + " ");
            }
        }

        static void Main(string[] args)
        {
            Random randomMumber = new Random();
            var size = 0;
            while ((size & 1) == 0)  /// parity checking
            {
                Console.WriteLine("Enter the size of quadratic matrix(odd number > 0)");
                size = Convert.ToInt32(Console.ReadLine());
            }

            int[,] array = new int[size,size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    array[i, j] = randomMumber.Next(10, 100);
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Spiral(array, size);
        }
    }
}
