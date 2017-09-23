using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeNamespace
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            poemTree = new BinaryTree<string>();
            poem = poem = new[]
            {
                "если",
                "я",
                "чешу",
                "в",
                "затылке",
                "не",
                "беда",
                "в.",
                "голове",
                "моей",
                "опилки",
                "да",
                "да.",
                "да.."
            };

            poemTree.Insert(50, "беда");
            poemTree.Insert(60, "опилки");
            poemTree.Insert(40, "не");
            poemTree.Insert(55, "голове");
            poemTree.Insert(70, "да");
            poemTree.Insert(30, "я");
            poemTree.Insert(58, "моей");
            poemTree.Insert(20, "если");
            poemTree.Insert(53, "в.");
            poemTree.Insert(35, "в");
            poemTree.Insert(75, "да.");
            poemTree.Insert(80, "да..");
            poemTree.Insert(33, "чешу");
            poemTree.Insert(37, "затылке");
        }

        [TestMethod]
        public void InsertTest()
        {
            poemTree.Insert(99, "olol");
            Assert.IsTrue(poemTree.Contains(99));
        }

        [TestMethod]
        public void RemoveTest()
        {
            poemTree.Remove(35);
            poemTree.Remove(50);
            int j = 0;
            foreach (string element in poemTree)
            {
                if ((j == 3) || (j == 6))
                {
                    ++j;
                }

                Assert.AreEqual(element, poem[j]);
                ++j;
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            poemTree.Remove(20);
            poemTree.Remove(58);
            Assert.IsFalse(poemTree.Contains(58));
            Assert.IsFalse(poemTree.Contains(20));
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            int j = 0;
            foreach (string element in poemTree)
            {
                Assert.AreEqual(element, poem[j]);
                ++j;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NonExistentItemException))]
        public void RemoveNonExistentKeyTest()
        {
            poemTree.Remove(9876);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateKeysException))]
        public void InsertDuplicateKeysTest()
        {
            poemTree.Insert(50, "второе в");
        }

        private BinaryTree<string> poemTree;
        private string[] poem;
    }
}