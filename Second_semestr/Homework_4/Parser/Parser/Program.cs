using System;
using ParseTreeNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ParseTree();
            tree.CreateTree("- * / 15 - 7 + 1 1 3 + 2 + 1 1");
            tree.Print();
        }
    }
}
