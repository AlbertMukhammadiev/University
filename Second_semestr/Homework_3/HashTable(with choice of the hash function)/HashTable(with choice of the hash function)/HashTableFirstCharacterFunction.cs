namespace HashTableNamespace
{
    /// <summary>
    /// hash table, that hashes by the first letter of the word
    /// </summary>
    public class HashTableFirstCharacterFunction : HashTable
    {
        public HashTableFirstCharacterFunction(int size) : base(size)
        {

        }

        public override int HashFunction(string word)
        {
            return word[0] % this.Size;
        }
    }
}