using SetNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListTests
{
    [TestClass]
    public class SetTest
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        [TestMethod]
        public void AddTest()
        {
            for (int i = 1; i < 10; i *= 2)
            {
                set.Add(i);
            }

            for (int i = 1; i < 10; i *= 2)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                set.Add(i);
            }

            set.Remove(4);
            Assert.IsFalse(set.Contains(4));
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                set.Add(i);
            }

            for (int i = 9; i >= 0; --i)
            {
                Assert.IsTrue(set.Contains(i));
            }

            Assert.IsFalse(set.Contains(12));
        }

        [TestMethod]
        public void IntersectTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                set.Add(i);
            }

            var secondSet = new Set<int>();
            for (int i = 3; i < 10; ++i)
            {
                secondSet.Add(i);
            }

            set.Intersect(secondSet);
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(4));
            Assert.IsFalse(set.Contains(5));
        }

        [TestMethod]
        public void UniteTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                set.Add(i);
            }

            var secondSet = new Set<int>();
            for (int i = 6; i < 10; ++i)
            {
                secondSet.Add(i);
            }

            set.Unite(secondSet);
            for (int i = 0; i < 10; ++i)
            {
                if (i == 5)
                {
                    continue;
                }

                Assert.IsTrue(set.Contains(i));
            }

            Assert.IsFalse(set.Contains(5));
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptySetException))]
        public void RemoveFromEmptyListTest()
        {
            set.Remove(5);
        }

        [TestMethod()]
        [ExpectedException(typeof(NonExistentItemException))]
        public void RemoveNonExistentItemTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                set.Add(i + 5);
            }

            set.Remove(3);
        }
    }
}

