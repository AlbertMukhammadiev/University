using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeNamespace
{
    [TestClass]
    public class BinaryTreeTest
    {
        private BinaryTree<string> tree;
        private string[] poem;

        [TestInitialize]
        public void Initialize()
        {
            tree = new BinaryTree<string>();
            poem = new string[14];

            int i = 0;
            poem[i] = "если";
            ++i;
            poem[i] = "я";
            ++i;
            poem[i] = "чешу";
            ++i;
            poem[i] = "в";
            ++i;
            poem[i] = "затылке";
            ++i;
            poem[i] = "не";
            ++i;
            poem[i] = "беда";
            ++i;
            poem[i] = "В";
            ++i;
            poem[i] = "голове";
            ++i;
            poem[i] = "моей";
            ++i;
            poem[i] = "опилки";
            ++i;
            poem[i] = "да";
            ++i;
            poem[i] = "yes";
            ++i;
            poem[i] = "ае";

            tree.Insert(50, "В");
            tree.Insert(10, "я");
            tree.Insert(70, "опилки");
            tree.Insert(90, "yes");
            tree.Insert(20, "в");
            tree.Insert(5, "если");
            tree.Insert(40, "беда");
            tree.Insert(60, "голове");
            tree.Insert(100, "ае");
            tree.Insert(15, "чешу");
            tree.Insert(65, "моей");
            tree.Insert(25, "затылке");
            tree.Insert(30, "не");
            tree.Insert(80, "да");
        }

        [TestMethod]
        public void InsertTest()
        {
            tree.Insert(99, "olol");
            Assert.IsTrue(tree.Contains(99));
        }

        [TestMethod]
        public void RemoveTest()
        {
            tree.Remove(50);
            Assert.IsFalse(tree.Contains(50));
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            int j = 0;
            foreach (string element in tree)
            {
                Assert.AreEqual(element, poem[j]);
                ++j;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NonExistentItemException))]
        public void RemoveNonExistentKeyTest()
        {
            tree.Remove(9876);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateValuesException))]
        public void InsertDuplicateKeysTest()
        {
            tree.Insert(50, "второе в");
        }
    }
}