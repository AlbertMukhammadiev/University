﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableNamespace
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;
        private AddFunction sum;
        private FirstCharacterFunction firstEl;
        private int size = 55;

        [TestInitialize]
        public void Initialize()
        {
            sum = new AddFunction();
            firstEl = new FirstCharacterFunction();
            hashTable = new HashTable(sum, size);
            hashTable.Add("Jacob");
            hashTable.Add("William");
            hashTable.Add("Christopher");
            hashTable.Add("Ryan");
            hashTable.Add("David");
            hashTable.Add("Alexander");
            hashTable.Add("James");
            hashTable.Add("Jonathan");
            hashTable.Add("Jose");
            hashTable.Add("Kevin");
            hashTable.Add("Luke");
            hashTable.Add("Cameron");
        }

        [TestMethod]
        public void AddTest()
        {
            hashTable.Add("Alex");
            Assert.IsTrue(hashTable.Contains("Alex"));
        }

        [TestMethod]
        public void ContainsTest()
        {
            Assert.IsTrue(hashTable.Contains("Jose"));
            Assert.IsTrue(hashTable.Contains("Ryan"));
            Assert.IsTrue(hashTable.Contains("Luke"));
            Assert.IsFalse(hashTable.Contains("Alex"));
        }

        [TestMethod]
        public void RemoveTest()
        {
            hashTable.Remove("James");
            hashTable.Remove("Jacob");
            Assert.IsFalse(hashTable.Contains("James"));
            Assert.IsFalse(hashTable.Contains("Jacob"));
        }

        [TestMethod]
        public void HashFunctionsTest()
        {
            Assert.IsTrue(sum.HashFunction("Zachet") > firstEl.HashFunction("Zachet"));
        }
    }
}