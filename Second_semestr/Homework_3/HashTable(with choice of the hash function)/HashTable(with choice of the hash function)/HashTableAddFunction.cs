namespace HashTableNamespace
{
    /// <summary>
    /// hash table, that hashes by the sum of all letters of the word
    /// </summary>
    public class HashTableAddFunction : HashTable
    {
        public HashTableAddFunction(int size) : base(size)
        {

        }

        /// <summary>
        /// applies some function to the word
        /// and returns the key that corresponds to the given parameter
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public override int HashFunction(string word)
        {
            int result = 0;
            int length = word.Length;
            for (int i = 0; i < length; ++i)
            {
                result += word[i];
            }

            return result % this.Size;
        }
    }
}
