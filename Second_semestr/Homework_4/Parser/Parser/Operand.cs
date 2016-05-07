using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTreeNamespace
{
    class Operand : Node
    {
        private int value;

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
