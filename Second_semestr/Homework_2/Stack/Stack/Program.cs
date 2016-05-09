using StackNamespace;
using System;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            try
            {
                stack.Pop();
                stack.PrintStack();
            }
            catch (EmptyStackException ex)
            {
                Console.WriteLine("Caught Exception");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}