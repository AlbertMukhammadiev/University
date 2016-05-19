namespace CalculatorNamespace
{
    /// <summary>
    /// interface of stack calculator
    /// </summary>
    interface ICalculator
    {
        void Add();

        void Subtract();

        void Multiply();

        void Divide();

        void Push(int value);

        int Result();
    }
}
