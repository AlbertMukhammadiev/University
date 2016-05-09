using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramNamespace
{
    public class Program
    {
        /// <summary>
        /// applies a given function to each element of a list
        /// and returns new list of results in the same order
        /// </summary>
        /// <param name="list"></param>
        /// <param name="convert"></param>
        /// <returns></returns>
        public static List<int> Map(List<int> list, Func<int, int> convert)
        {
            var sizeOfList = list.Count();
            var newList = new List<int>();
            for (int i = 0; i < sizeOfList; ++i)
            {
                newList.Add(convert(list[i]));
            }

            return newList;
        }

        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 5, 10 };
            var newList = Map(list, element => element * 2);
            foreach (var element in newList)
            {
                Console.Write(element + " ");
            }
        }
    }
}