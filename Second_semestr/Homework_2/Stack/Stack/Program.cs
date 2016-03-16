using StackNamespace;
using System;
using MyException;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            try
            {
                //Stack excStack = new Stack();
                stack.Pop();
            }
            catch (MyNullReferenceException ex)
            {
                Console.WriteLine("Caught Exception");
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            stack.Pop();
        }
    }
}