﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_2_Fibonacci_
{
    class Program
    {
        /// <summary>
        /// multiplies two matrices(the result of the multiplication is written in "result")
        /// </summary>
        /// <param name="result"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static void MatrixMultiplication(int[,] result, int[,] matrix)
        {
            var a11 = result[0, 0];
            var a12 = result[0, 1];
            var a22 = result[1, 1];

            var b11 = matrix[0, 0];
            var b12 = matrix[0, 1];
            var b22 = matrix[1, 1];

            result[0, 0] = b11 * a11 + b12 * a12;
            result[0, 1] = b11 * a12 + b12 * a22;
            result[1, 0] = result[0, 1];
            result[1, 1] = b12 * a12 + b22 * a22;
        }

        /// <summary>
        /// returns the n-th Fibonacci number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Fibonacci(int number)
        {
            int[,] matrix = { { 1, 1 }, { 1, 0 } };
            int[,] result = { { 1, 1 }, { 1, 0 } };

            while (number > 0)
            {
                if ((number & 1) == 1)   /// parity checking
                {
                    MatrixMultiplication(result, matrix);
                }
                MatrixMultiplication(matrix, matrix);
                number = number >> 1;
            }

            return result[1, 1];
        }

        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine("enter the sequence number of Fibonacci number:");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write(num + "th number of Fibonacci number is ");

            if (num < 0)
            {
                num *= -1;
                if ((num & 1) == 1)   /// parity checking
                {
                    Console.WriteLine(Fibonacci(num));
                }
                else
                {
                    Console.WriteLine("-" + Fibonacci(num));
                }
                return;
            }

            Console.WriteLine(Fibonacci(num));
        }
    }
}
