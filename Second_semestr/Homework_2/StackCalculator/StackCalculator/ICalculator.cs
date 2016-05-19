namespace CalculatorNamespace
{
    /// <summary>
    /// interface of stack calculator
    /// </summary>
    interface ICalculator
    {
        /// <summary>
        /// takes two elements from the stack, finds their sum and pushes the result to the top of the stack
        /// </summary>
        void SumUp();

        /// <summary>
        /// takes two elements from the stack, finds their difference and pushes the result to the top of the stack
        /// </summary>
        void Subtract();

        /// <summary>
        /// takes two elements from the stack, multiplies them and pushes the result to the top of the stack
        /// </summary>
        void Multiply();

        /// <summary>
        /// takes two elements from the stack, finds their quotient and pushes the result to the top of the stack
        /// </summary>
        void Divide();

        /// <summary>
        /// pushes the given value to the top of the stack
        /// </summary>
        /// <param name="value"></param>
        void Push(int value);

        /// <summary>
        /// returns the result of the performed calculations
        /// </summary>
        /// <returns></returns>
        int Result();
    }
}