using System;
using ListNamespace;

namespace HashTableNamespace
{
    /// <summary>
    /// a class that represents a hash table
    /// </summary>
    public class HashTable : IHashTable
    {
        /// <summary>
        /// class constructor
        /// </summary>
        public HashTable()
        {
            hashTable = new List[101];
            for (int i = 0; i < 101; ++i)
            {
                hashTable[i] = new List();
            }
        }

        public void Add(string word)
        {
            int i = this.hashFunction(word);
            if (!this.Contains(word))
            {
                this.hashTable[i].Add(word);
            }
            else
            {
                Console.WriteLine("this item already exists in the hash table");
            }
        }

        public void Remove(string word)
        {
            int i = hashFunction(word);
            hashTable[i].Remove(word);
        }

        public bool Contains(string word)
        {
            int i = hashFunction(word);
            return hashTable[i].Contains(word);
        }

        public void Print()
        {
            Console.WriteLine("Hash table:");
            int size = hashTable.GetLength(0);
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine("List number " + i + ":");
                hashTable[i].Print();
                Console.WriteLine();
            }
        }

        private List[] hashTable;

        private int hashFunction(string word)
        {
            int result = 0;
            int length = word.Length;
            for (int i = 0; i < length; ++i)
            {
                result += word[i];
            }

            return result % hashTable.GetLength(0);
        }
    }
}
