using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramNamespace;

namespace FilterTests
{
    [TestClass]
    public class FilterTest
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>() { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
        }

        [TestMethod]
        public void EvenNumbersTest()
        {
            var listOfEvenNumbers = Program.Filter(list, element => element % 2 == 0);
            foreach(var element in listOfEvenNumbers)
            {
                Assert.IsTrue(element % 2 == 0);
            }
        }

        [TestMethod]
        public void PositiveNumbersTest()
        {
            var listOfEvenNumbers = Program.Filter(list, element => element > 0);
            foreach (var element in listOfEvenNumbers)
            {
                Assert.IsTrue(element > 0);
            }
        }
    }
}