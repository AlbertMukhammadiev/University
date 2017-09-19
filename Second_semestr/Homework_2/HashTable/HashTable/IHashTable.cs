namespace HashTableNamespace
{
    /// <summary>
    /// interface of hash table
    /// </summary>
    interface IHashTable
    {
        /// <summary>
        /// adds an object to the hash table
        /// </summary>
        /// <param name="word"></param>
        void Add(string word);

        /// <summary>
        /// removes the first occurrence of a specific object from the hash table
        /// </summary>
        /// <param name="word"></param>
        void Remove(string word);

        /// <summary>
        /// Determines whether an element is in the hash table
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        bool Contains(string word);

        /// <summary>
        /// displays all elements of hash table into the console
        /// </summary>
        void Print();
    }
}
