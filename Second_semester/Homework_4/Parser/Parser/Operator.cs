namespace ParseTreeNamespace
{
    /// <summary>
    /// a node that represents a mathematical operation
    /// </summary>
    public abstract class Operator : Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        /// <summary>
        /// the operation sign
        /// </summary>
        public char Token { get; set; }
    }
}
