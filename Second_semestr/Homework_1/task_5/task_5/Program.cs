using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_5
{
    class Program
    {
        /// <summary>
        /// sorts the columns of the matrix by the first column elements
        /// </summary>
        /// <param name="matrix"></param>
        private static void BubbleSort(int[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);
            for (int i = 0; i < width - 1; ++i)
            {
                for (int j = 0; j < width - i - 1; ++j)
                    if (matrix[0, j + 1] < matrix[0, j])
                    {
                        for (int k = 0; k < height; ++k)
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k, j + 1];
                            matrix[k, j + 1] = temp;
                        }
                    }
            }
        }

        /// <summary>
        /// prints the elements of the matrix to console
        /// </summary>
        /// <param name="matrix"></param>
        private static void PrintMatrix(int[,] matrix)
        {
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("enter the height of matrix:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the width of matrix:");
            int width = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[height, width];
            Random randomMumber = new Random();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    matrix[i, j] = randomMumber.Next(10, 100);
                }
            }

            Console.WriteLine("the original matrix:");
            PrintMatrix(matrix);
            BubbleSort(matrix);
            Console.WriteLine("\nsorted matrix:");
            PrintMatrix(matrix);
        }
    }
}
