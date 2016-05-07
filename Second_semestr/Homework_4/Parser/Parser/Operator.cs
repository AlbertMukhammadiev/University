using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseTreeNamespace
{
    public abstract class Operator : Node
    {
        /// <summary>
        /// the operation sign
        /// </summary>
        public char Token { get; set; }

        /// <summary>
        /// olololololo
        /// </summary>
        /// <returns></returns>
        public override int Calculate()
        {
            return 1212121;
        }

        /// <summary>
        /// ololololololololo
        /// </summary>
        public override void PrintNode()
        {

        }
    }
}
