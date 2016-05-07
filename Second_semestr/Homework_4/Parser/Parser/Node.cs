namespace ParseTreeNamespace
{
    public abstract class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        /// <summary>
        /// returns the value of a node after applying the operation
        /// </summary>
        /// <returns></returns>
        public abstract int Calculate();

        /// <summary>
        /// prints the node to the console
        /// </summary>
        public abstract void PrintNode();
    }
}