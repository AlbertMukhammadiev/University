using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramNamespace
{
    public class Program
    {
        /// <summary>
        /// applies a given function to each element of a list, returning a list of results in the same order
        /// </summary>
        /// <param name="list"></param>
        /// <param name="convert"></param>
        /// <returns></returns>
        public static void Map(List<int> list, Func<int, int> convert)
        {
            var sizeOfList = list.Count();
            for (int i = 0; i < sizeOfList; ++i)
            {
                list[i] = convert(list[i]);
            }
        }

        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 5, 10 };
            Map(list, element => element * 2);
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }
        }
    }
}