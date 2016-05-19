namespace StackNamespace
{
    /// <summary>
    /// LIFO
    /// </summary>
    interface IStack
    {
        /// <summary>
        /// pushes the value to the top of the stack
        /// </summary>
        /// <param name="value"></param>
        void Push(int value);

        /// <summary>
        /// returns the top value of the stack
        /// </summary>
        /// <returns></returns>
        int Top();

        /// <summary>
        /// removes the top element
        /// </summary>
        void Pop();

        /// <summary>
        /// if stack is empty, returns "true", else returns "false"
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// displays all elements of stack into the console
        /// </summary>
        void PrintStack();
    }
}