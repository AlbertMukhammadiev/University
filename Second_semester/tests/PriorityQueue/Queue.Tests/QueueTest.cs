using PriorityQueueNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueTests
{
    [TestClass]
    public class StackTest
    {
        PriorityQueue queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue();
        }

        [TestMethod]
        public void DequeueTest()
        {
            queue.Enqueue('a', 1);
            queue.Enqueue('b', 2);
            queue.Dequeue();
            Assert.AreEqual(queue.Dequeue(), 'a');
        }

        [TestMethod]
        public void EnqueueTest()
        {
            queue.Enqueue('a', 3);
            queue.Enqueue('b', 4);
            queue.Enqueue('c', 2);
            queue.Enqueue('d', 1);
            string word = "";
            for (int i = 0; i < 4; ++i)
            {
                var symbol = queue.Dequeue();
                word += symbol;
            }

            Assert.AreEqual(word, "bacd");
        }

        [TestMethod()]
        [ExpectedException(typeof(MyException.EmptyQueueException))]
        public void DequeueFromEmptyQueueTest()
        {
            var value = queue.Dequeue();
        }

        [TestMethod()]
        [ExpectedException(typeof(MyException.EmptyQueueException))]
        public void PrintEmptyQueueTest()
        {
            queue.PrintQueue();
        }
    }
}
