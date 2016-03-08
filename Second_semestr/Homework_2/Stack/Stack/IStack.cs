namespace IStackNamespace
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

        int GetValue();

        /// <summary>
        /// removes the top element
        /// </summary>
        void Pop();

        bool IsEmpty();

        /// <summary>
        /// displays all elements of stack into the console
        /// </summary>
        void PrintStack();
    }
}
