using System;
using HashTableNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var length = input.Length;
            HashTable hashTable = new HashTable();
            var j = 0;
            for (int i = 0; i < length; ++i)
            {
                string word = "";
                while (input[j] != ' ')
                {
                    word += input[j];
                }

                i = j;
                j = 0;
                hashTable.AddValueToTable(word);
                word = "";
            }

            hashTable.PrintHashTable();
        }
    }
}
