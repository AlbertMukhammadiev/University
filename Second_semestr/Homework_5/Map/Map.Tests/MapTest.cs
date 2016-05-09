using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramNamespace;

namespace MapTests
{
    [TestClass]
    public class MapTest
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>() { 1, 3, 2, 4 };
        }

        /// <summary>
        /// checks the order of elements in the list. Map must not spoil the order of the elements
        /// </summary>
        [TestMethod]
        public void MapOrderTest()
        {
            Program.Map(list, element => element * 3);
            Assert.IsTrue(list[1] > list[2]);
            Assert.IsTrue(list[0] < list[1]);
            Assert.IsTrue(list[2] < list[3]);
        }

        [TestMethod]
        public void MapSqrTest()
        {
            Program.Map(list, element => element * element);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(9, list[1]);
        }
    }
}
