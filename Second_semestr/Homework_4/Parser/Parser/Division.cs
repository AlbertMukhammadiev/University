using System;

namespace ParseTreeNamespace
{
    /// <summary>
    /// a node that is a quotient of the left son(dividend) and right son(divisor)
    /// </summary>
    public class Division : Operator
    {
        /// <summary>
        /// returns the quotient of the left child(dividend) and right child(divisor)
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            var divisor = this.Right.Calculate();
            if (divisor == 0)
            {
                throw new MyDividedByZeroException();
            }

            return this.Left.Calculate() / divisor;
        }

        /// <summary>
        /// prints the division of the left child(dividend) and right child(divisor) in infix form
        /// </summary>
        public override void PrintNode()
        {
            Console.Write("( ");
            this.Left.PrintNode();
            Console.Write(" / ");
            this.Right.PrintNode();
            Console.Write(" )");
        }
    }
}
