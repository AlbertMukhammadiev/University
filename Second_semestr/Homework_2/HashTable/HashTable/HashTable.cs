using IHashTableNamespace;
using System;
using ListNamespace;

namespace HashTableNamespace
{
    class HashTable : IHashTable
    {
        List[] hashTable = new List[5];

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

        public void AddValueToTable(string word)
        {
            int i = hashFunction(word);
            hashTable[i].AddListElement(word);
        }

        public void DeleteValue(string word)
        {
            int i = hashFunction(word);
            hashTable[i].DeleteElement(word);
        }

        public bool IsExist(string word)
        {
            int i = hashFunction(word);
            return hashTable[i].IsExist(word);
        }

        public void PrintHashTable()
        {
            Console.WriteLine("Hash table:");
            int size = hashTable.GetLength(0);
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine("List number " + i + ":");
                hashTable[i].PrintList();
                Console.WriteLine();
            }
        }
    }
}
