using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> tree = new BinaryTree<string>();

            tree.Insert(50, "и");
            tree.Insert(60, "н");
            tree.Insert(40, "л");
            tree.Insert(55, "в");
            tree.Insert(70, "о");
            tree.Insert(30, "р");
            tree.Insert(53, "т");
            tree.Insert(58, "и");
            tree.Insert(35, "й");
            tree.Insert(33, "и");
            tree.Insert(37, " ");
            tree.Insert(80, "в");
            tree.Insert(20, "ю");  

            tree.PrintTree(0);

        }
    }
}
