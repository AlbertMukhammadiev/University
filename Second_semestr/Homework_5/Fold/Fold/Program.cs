using System;
using System.Collections.Generic;

namespace ProgramNamespace
{
    public class Program
    {
        /// <summary>
        /// converts data structures to a single atomic value using the given function
        /// </summary>
        /// <param name="list"></param>
        /// <param name="convert"></param>
        /// <returns></returns>
        public static int Fold(List<int> list, int acc, Func<int, int, int> convert)
        {
            int result = acc;
            foreach (var element in list)
            {
                result = convert(result, element);
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Fold(new List<int>() { 1, 0, 3 }, 1, (acc, elem) => acc + elem));
        }
    }
}