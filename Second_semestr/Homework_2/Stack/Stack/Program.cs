using System;
using System.Threading;
using StackNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack stack = new Stack();
            //Gusigagaga();
            int a = 0;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Push(a);
            ++a;
            stack.Pop();
            a = stack.GetValue();
            stack.PrintStack();
        }
    }
}