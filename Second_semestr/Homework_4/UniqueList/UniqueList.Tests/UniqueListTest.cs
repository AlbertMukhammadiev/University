using UniqueListNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListTests
{
    [TestClass]
    public class UniqueListTest
    {
        UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
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
        public void AddListElementTest()
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
        public void DeleteListElementTest()
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

        [TestMethod]
        [ExpectedException(typeof(MyException.DuplicateValuesException))]
        public void AddListElementDuplicateValuesTest()
        {
            list.AddListElement(1);
            list.AddListElement(1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException.DuplicateValuesException))]
        public void AddWithKeepingOrderDuplicateValuesTest()
        {
            list.AddWithKeepingOrder(1);
            list.AddWithKeepingOrder(1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException.EmptyListException))]
        public void EmptyListExceptionTest()
        {
            list.PrintList();
            list.DeleteListElement(3);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException.NonExistentItemException))]
        public void NonExistentItemExceptionTest()
        {
            list.AddListElement(2);
            list.AddListElement(4);

            list.DeleteListElement(5);
            var value = list.GetIValue(10);
        }
    }
}
