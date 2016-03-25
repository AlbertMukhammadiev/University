using ListNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListTests
{
    [TestClass]
    public class ListTest
    {
        List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddWithKeepingOrderTest()
        {
            list.AddWithKeepingOrder(5);
            list.AddWithKeepingOrder(3);
            var firstElement = list.GetIValue(0);
            var secondElement = list.GetIValue(1);
            Assert.IsTrue(firstElement <= secondElement);
        }

        [TestMethod]
        public void AddListElement()
        {
            for (int i = 1; i < 10; i *= 2)
            {
                list.AddListElement(i);
            }

            Assert.AreEqual(1, list.GetIValue(0));
            Assert.AreEqual(2, list.GetIValue(1));
            Assert.AreEqual(8, list.GetIValue(3));
        }

        [TestMethod]
        public void DeleteListElement()
        {
            for (int i = 0; i < 10; ++i)
            {
                list.AddListElement(i);
            }

            list.DeleteListElement(4);
            Assert.AreEqual(5, list.GetIValue(4));

            list.DeleteListElement(0);
            Assert.AreEqual(1, list.GetIValue(0));
        }

        [TestMethod()]
        [ExpectedException(typeof(MyException.EmptyListException))]
        public void EmptyListException()
        {
            list.PrintList();
            list.DeleteListElement(3);
        }

        [TestMethod()]
        [ExpectedException(typeof(MyException.NonExistentItemException))]
        public void NonExistentItemException()
        {
            list.AddListElement(2);
            list.AddListElement(4);

            list.DeleteListElement(5);
            var value = list.GetIValue(10);
        }
    }
}
