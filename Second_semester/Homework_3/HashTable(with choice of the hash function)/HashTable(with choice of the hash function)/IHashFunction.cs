namespace HashTableNamespace
{
    /// <summary>
    /// interface of hash function
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// applies the hash function to the given word and returns index
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        int HashFunction(string word);
    }
}
