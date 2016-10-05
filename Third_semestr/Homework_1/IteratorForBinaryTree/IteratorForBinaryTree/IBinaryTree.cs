namespace BinaryTreeNamespace
{
    interface IBinaryTree<T>
    {
        /// adds a node with key K and value V into the tree
        void Insert(int key, T value);

        /// checks for the existence of the node with the given key
        bool Contains(int key);

        /// removes the tree node with the given key
        void Remove(int key);
    }
}