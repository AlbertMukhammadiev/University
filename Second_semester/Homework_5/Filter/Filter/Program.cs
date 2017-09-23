using System;
using System.Collections.Generic;

namespace ProgramNamespace
{
    public class Program
    {
        /// <summary>
        /// processes a list to produce a new list containing exactly those elements of the original list for which a given predicate returns the boolean value true
        /// </summary>
        /// <param name="list"></param>
        /// <param name="convert"></param>
        /// <returns></returns>
        public static List<int> Filter(List<int> list, Func<int, bool> convert)
        {
            var resultList = new List<int>();
            foreach (var element in list)
            {
                if (convert(element))
                {
                    resultList.Add(element);
                }
            }

            return resultList;
        }

        static void Main(string[] args)
        {
            var list = new List<int> { -2, 5, -12, 10 };
            var resultList = Filter(list, element => element > 0);
            foreach (var element in resultList)
            {
                Console.Write(element + " ");
            }
        }
    }
}