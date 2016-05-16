using System;
using ListNamespace;


namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            for (int i = 10; i > 1; --i)
            {
                list.AddWithKeepingOrder(i);
                list.AddWithKeepingOrder(i+1);
            }
           
            Console.WriteLine(list.Count);
        }
    }
}
