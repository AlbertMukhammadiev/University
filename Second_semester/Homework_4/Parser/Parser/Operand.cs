using System;

namespace ParseTreeNamespace
{
    /// <summary>
    /// the node that represents an integer
    /// </summary>
    public class Operand : Node
    {
        private int value;

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="value"></param>
        public Operand(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// returns a value of the operand
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return value;
        }

        /// <summary>
        /// prints a value of the operand 
        /// </summary>
        public override void PrintNode()
        {
            Console.Write(value);
        }
    }
}
