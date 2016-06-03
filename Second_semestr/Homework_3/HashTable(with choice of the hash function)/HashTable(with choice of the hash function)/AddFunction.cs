using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashTableNamespace
{
    /// <summary>
    /// hash table, that hashes by sum of all elements of the word
    /// </summary>
    public class AddFunction : IHashFunction
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="Size"></param>
        public AddFunction(int size)
        {
            this.Size = size;
        }
        
        /// <summary>
        /// applies some function to the word
        /// and returns the key that corresponds to the given parameter
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int HashFunction(string word)
        {
            int result = 0;
            int length = word.Length;
            for (int i = 0; i < length; ++i)
            {
                result += word[i];
            }

            return result % this.Size;
        }

        public int Size { get; }
    }
}
