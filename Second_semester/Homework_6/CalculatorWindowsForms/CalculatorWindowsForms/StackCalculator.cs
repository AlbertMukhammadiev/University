using StackNamespace;

namespace StackCalculatorNamespace
{
    /// <summary>
    /// class that implements a stack-based calculator
    /// </summary>
    public class StackCalculator : IStackCalculator
    {
        public double Result() => stack.Top();

        public bool IsEmpty() => stack.IsEmpty();

        public void Clear()
        {
            stack.Clear();
        }

        public void Push(double value)
        {
            stack.Push(value);
        }

        public void Operation(char sign)
        {
            switch (sign)
            {
                case '+':
                    {
                        this.SumUp();
                        break;
                    }
                    
                case '-':
                    {
                        this.Subtract();
                        break;
                    }
                    
                case '*':
                    {
                        this.Multiply();
                        break;
                    }

                case '/':
                    {
                        this.Divide();
                        break;
                    }
                    
                default:
                    {
                        //Console.WriteLine("Default case");
                        break;
                    }
            }
        }

        private void SumUp()
        {
            var first = stack.Top();
            stack.Pop();
            var second = stack.Top();
            stack.Pop();
            stack.Push(first + second);
        }

        private void Subtract()
        {
            var first = stack.Top();
            stack.Pop();
            var second = stack.Top();
            stack.Pop();
            stack.Push(second - first);
        }

        private void Multiply()
        {
            var first = stack.Top();
            stack.Pop();
            var second = stack.Top();
            stack.Pop();
            stack.Push(first * second);
        }

        private void Divide()
        {
            var first = stack.Top();
            if (first == 0)
            {
                throw new MyDivideByZeroException("you can not divide by zero");
            }

            stack.Pop();
            var second = stack.Top();
            stack.Pop();
            stack.Push(second / first);
        }

        private Stack<double> stack = new Stack<double>();
    }
}