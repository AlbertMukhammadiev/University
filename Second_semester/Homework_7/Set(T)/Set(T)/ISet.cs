namespace SetNamespace
{
    /// <summary>
    /// interface of Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ISet<T>
    {
        /// <summary>
        /// Adds the specified element to Set
        /// </summary>
        /// <param name="value"></param>
        void Add(T value);

        /// <summary>
        /// Removes the specified element from Set
        /// </summary>
        /// <param name="value"></param>
        void Remove(T value);

        /// <summary>
        /// displays all elements of Set into the console
        /// </summary>
        void Print();

        /// <summary>
        /// Determines whether an element is in Set
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        bool Contains(T values);

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present in that object and in the specified set
        /// </summary>
        /// <param name="set"></param>
        void Intersect(Set<T> set);

        /// <summary>
        /// Modifies the current Set<T> object so that it contains all elements that are present in either the current object or the specified set
        /// </summary>
        /// <param name="set"></param>
        void Unite(Set<T> set);
    }
}
