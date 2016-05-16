namespace ListNamespace
{
    /// <summary>
    /// interface of singly linked list
    /// </summary>
    interface IList
    {
        /// <summary>
        /// adds an object to the end of the List
        /// </summary>
        void Add(int value);

        /// <summary>
        /// displays all elements of List into the console
        /// </summary>
        void Print();

        /// <summary>
        /// removes the first occurrence of a specific object from the List
        /// </summary>
        /// <param name="value"></param>
        void Remove(int value);

        /// <summary>
        /// adds a new element to the List with keeping order of elements
        /// </summary>
        /// <param name="value"></param>
        void AddWithKeepingOrder(int value);

        /// <summary>
        /// returns a value of the List item with the specified number
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int GetValue(int i);

        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item"></param>
        bool Contains(int value);
    }
}
