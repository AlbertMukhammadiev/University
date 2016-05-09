using StackNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTests
{
    [TestClass]
    public class StackTest
    {
        private Stack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack();
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(stack.GetValue(), 1);
        }

        [TestMethod]
        public void PushTest()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(8);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyStackException))]
        public void GetFromEmptyStackTest()
        {
            var topValue = stack.GetValue();
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyStackException))]
        public void PopFromEmptyStackTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void GetValueTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.GetValue());
            stack.Pop();
            Assert.AreEqual(2, stack.GetValue());
            stack.Pop();
            Assert.AreEqual(1, stack.GetValue());
        }
    }
}
