namespace StackCalculatorNamespace
{
    /// <summary>
    /// interface of stack calculator
    /// </summary>
    interface IStackCalculator
    {
        /// <summary>
        /// returns the result of the performed calculations
        /// </summary>
        /// <returns></returns>
        double Result();

        /// <summary>
        /// if stack is empty, returns "true", else returns "false"
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Removes all objects from the StackCalculator
        /// </summary>
        void Clear();

        /// <summary>
        /// pushes the given value to the top of the stack
        /// </summary>
        /// <param name="value"></param>
        void Push(double value);

        /// <summary>
        /// takes two elements from the stack,
        /// performs the operation(that depends on sign)
        /// and pushes the result to the top of the stack
        /// </summary>
        void Operation(char sign);
    }
}