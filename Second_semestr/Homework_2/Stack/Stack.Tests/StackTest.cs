using StackNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTests
{
    [TestClass]
    public class StackTest
    {
        Stack stack;

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
    }
}
