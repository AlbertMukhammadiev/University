using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task_1_factorial_
{
    class Program
    {
        static int RecursionFactorial(int num)
        {
            if ((num == 1) || (num == 0))
            {
                return 1;
            }

            return num * RecursionFactorial(num - 1);
        }

        static int IterationFactorial(int num)
        {
            if ((num == 1) || (num == 0))
            {
                return 1;
            }

            int result = 1;
            for (var i = 2; i <= num; ++i)
            {
                result *= i;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int num  = 0;
            Console.WriteLine("Enter the integer >= 0, please:");
            num = Convert.ToInt32(Console.ReadLine());

            while (num < 0)
            {
                Console.WriteLine("You have entered an invalid number!");
                Console.WriteLine("Enter the correct number, please");
                num = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.WriteLine("recursive method\nThe factorial of " + num + " = " + RecursionFactorial(num));

            Console.WriteLine("\nan iterative method\nThe factorial of " + num + " = " + IterationFactorial(num));
        }
    }
}
