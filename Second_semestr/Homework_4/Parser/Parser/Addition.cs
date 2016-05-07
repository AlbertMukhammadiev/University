using System;

namespace ParseTreeNamespace
{
    class Addition : Operator
    {
        /// <summary>
        /// returns the sum of the left child and right child
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return this.Left.Calculate() + this.Right.Calculate();
        }

        /// <summary>
        /// prints the addition of the left child and right child in infix form
        /// </summary>
        public override void PrintNode()
        {
            Console.Write("( ");
            this.Left.PrintNode();
            Console.Write(" + ");
            this.Right.PrintNode();
            Console.Write(" )");
        }
    }
}
