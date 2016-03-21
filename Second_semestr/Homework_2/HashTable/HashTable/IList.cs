namespace IListNamespace
{
    interface IList
    {
        /// <summary>
        /// adds new value to list(without sorting)
        /// </summary>
        void AddListElement(string value);

        /// <summary>
        /// displays entire list into the console
        /// </summary>
        void PrintList();

        bool IsExist(string value);
    }
}