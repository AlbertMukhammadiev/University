namespace IHashTableNamespace
{
    interface IHashTable
    {
        void AddValueToTable(string word);

        void DeleteValue(string word);

        bool IsExist(string word);

        void PrintHashTable();
    }
}
