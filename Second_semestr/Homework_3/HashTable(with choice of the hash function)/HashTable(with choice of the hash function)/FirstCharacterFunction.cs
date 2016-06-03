namespace HashTableNamespace
{
    /// <summary>
    /// hash table, that hashes by the first letter of the word
    /// </summary>
    public class FirstCharacterFunction
    {
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="Size"></param>
        public FirstCharacterFunction(int size)
        {
            this.Size = size;
        }

        public int HashFunction(string word)
        {
            return word[0] % this.Size;
        }

        public int Size { get; }
    }
}

