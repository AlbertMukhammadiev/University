namespace HashTableNamespace
{
    /// <summary>
    /// hash table, that hashes by the first letter of the word
    /// </summary>
    public class FirstCharacterFunction : IHashFunction
    {
        public int HashFunction(string word)
        {
            return word[0];
        }
    }
}

