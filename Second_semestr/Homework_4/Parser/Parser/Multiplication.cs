using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTreeNamespace
{
    class Multiplication : Operator
    {
        /// <summary>
        /// returns the product of the left child and right child
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return this.Left.Calculate() * this.Right.Calculate();
        }

        /// <summary>
        /// prints the multiplication of the left child and right child in infix form
        /// </summary>
        public override void PrintNode()
        {
            Console.Write("( ");
            this.Left.PrintNode();
            Console.Write(" * ");
            this.Right.PrintNode();
            Console.Write(" )");
        }
    }
}
