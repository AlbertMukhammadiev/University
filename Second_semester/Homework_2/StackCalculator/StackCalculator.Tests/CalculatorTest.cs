using StackNamespace;
using CalculatorNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        private Calculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void DivisionTest()
        {
            calculator.Push(4);
            calculator.Push(2);
            calculator.Divide();
            Assert.IsTrue(calculator.Result() == 2);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            calculator.Push(4);
            calculator.Push(2);
            calculator.Push(0);
            calculator.Multiply();
            calculator.Multiply();
            Assert.IsTrue(calculator.Result() == 0);
        }

        [TestMethod]
        public void AdditionTest()
        {
            calculator.Push(4);
            calculator.Push(3);
            calculator.Push(10);
            calculator.SumUp();
            Assert.IsTrue(calculator.Result() == 13);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            calculator.Push(99);
            calculator.Push(88);
            calculator.Subtract();
            Assert.IsTrue(calculator.Result() == 11);
        }

        [TestMethod()]
        [ExpectedException(typeof(MyDivideByZeroException))]
        public void DividedByZeroTest()
        {
            calculator.Push(99);
            calculator.Push(14);
            calculator.Push(5);
            calculator.Push(5);
            calculator.Subtract();
            calculator.Multiply();
            calculator.Divide();
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyStackException))]
        public void InvalidExpressionTest()
        {
            calculator.Push(5);
            calculator.Divide();
        }
    }
}