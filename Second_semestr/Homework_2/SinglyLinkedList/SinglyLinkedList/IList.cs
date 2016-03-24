namespace ListNamespace
{
    interface IList
    {
        /// <summary>
        /// adds new value to list(without sorting)
        /// </summary>
        void AddListElement(int value);

        /// <summary>
        /// displays entire list into the console
        /// </summary>
        void PrintList();

        /// <summary>
        /// removes the list item with the specified value
        /// </summary>
        /// <param name="value"></param>
        void DeleteListElement(int value);

        /// <summary>
        /// adds a new value to the list with keeping order of elements
        /// </summary>
        /// <param name="value"></param>
        void AddWithKeepingOrder(int value);

        /// <summary>
        /// returns a value of the list item with the specified number
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int GetValue(int i);
    }
}
