using StackNamespace;

namespace CalculatorNamespace
{
    /// <summary>
    /// class that implements a stack-based calculator
    /// </summary>
    public class Calculator : ICalculator
    {
        public void SumUp()
        {
            int first = stack.Top();
            stack.Pop();
            int second = stack.Top();
            stack.Pop();
            stack.Push(first + second);
        }

        public void Subtract()
        {
            int first = stack.Top();
            stack.Pop();
            int second = stack.Top();
            stack.Pop();
            stack.Push(second - first);
        }

        public void Multiply()
        {
            int first = stack.Top();
            stack.Pop();
            int second = stack.Top();
            stack.Pop();
            stack.Push(first * second);
        }

        public void Divide()
        {
            int first = stack.Top();
            if (first == 0)
            {
                throw new MyDividedByZeroException("you can not divide by zero");
            }

            stack.Pop();
            int second = stack.Top();
            stack.Pop();
            stack.Push(second / first);
        }

        public void Push(int value)
        {
            stack.Push(value);
        }

        public int Result() => stack.Top();

        private Stack stack = new Stack();
    }
}