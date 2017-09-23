using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BinaryTreeNamespace
{
    /// <summary>
    /// binary tree with iterator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IBinaryTree<T>, IEnumerable<T>
    {
        public enum InOrder
        {
            Ascending,
            Descending
        };

        /// <summary>
        /// adds a node with key K and value V into the tree
        /// </summary>
        /// <param name="key">key of node</param>
        /// <param name="value">value of node</param>
        public void Insert(int key, T value)
        {
            if (this.root == null)
            {
                this.root = new Node(key, value);
                return;
            }

            if (this.root.Key == key)
            {
                throw new DuplicateKeysException();
            }

            Node i = this.root;
            while ((i.Left != null) || (i.Right != null))
            {
                if (i.Key == key)
                {
                    throw new DuplicateKeysException("the node with the same key already exists in the tree");
                }

                if ((i.Left != null) && (key < i.Key))
                {
                    i = i.Left;
                }
                else if ((i.Right != null) && (key > i.Key))
                {
                    i = i.Right;
                }
                else if ((i.Right == null) && (key > i.Key))
                {
                    i.Right = new Node(key, value);
                    return;
                }
                else if ((i.Left == null) && (key < i.Key))
                {
                    i.Left = new Node(key, value);
                    return;
                }
            }

            if (key < i.Key)
            {
                i.Left = new Node(key, value);
            }
            else if (key > i.Key)
            {
                i.Right = new Node(key, value);
            }
        }

        /// <summary>
        /// checks for the existence of the node with the given key
        /// </summary>
        /// <param name="key">key of node</param>
        /// <returns></returns>
        public bool Contains(int key) => this.GetNode(key) != null;

        /// <summary>
        /// removes the tree node with the given key
        /// </summary>
        /// <param name="key">key of node</param>
        public void Remove(int key)
        {
            Node required = this.GetNode(key);
            if (required == null)
            {
                throw new NonExistentItemException("the tree is empty");
            }

            
            if (this.root.Key == key)
            {

                if ((this.root.Left == null) && (this.root.Right == null))
                {
                    this.root = null;
                    return;
                }

                
                if ((this.root.Left != null) && (this.root.Right != null))
                {
                    Node position = this.root.Left;
                    if (position.Right == null)
                    {
                        position.Right = this.root.Right;
                        this.root = position;
                        return;
                    }

                    Node previous = position;
                    while (position.Right != null)
                    {
                        previous = position;
                        position = position.Right;
                    }

                    previous.Right = position.Left;
                    position.Left = this.root.Left;
                    position.Right = this.root.Right;
                    this.root = position;
                    return;
                }

                if ((this.root.Left == null) && (this.root.Right != null))
                {
                    this.root = this.root.Right;
                    return;
                }

                if ((this.root.Left != null) && (this.root.Right == null))
                {
                    this.root = this.root.Left;
                    return;
                }
            }

            Node slide = this.root;
            bool fromRight = false;
            Node parent = slide;
            while (true)
            {
                if (slide.Left != null)
                {
                    if (slide.Left.Key == key)
                    {
                        parent = slide;
                        slide = slide.Left;
                        fromRight = true;
                        break;
                    }
                }

                if (slide.Right != null)
                {
                    if (slide.Right.Key == key)
                    {
                        parent = slide;
                        slide = slide.Right;
                        fromRight = false;
                        break;
                    }
                }

                if (key < slide.Key)
                {
                    slide = slide.Left;
                }
                else if (key > slide.Key)
                {
                    slide = slide.Right;
                }
            }

            if ((required.Left == null) && (required.Right == null))
            {
                if (fromRight)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }

                return;
            }

            if ((required.Left == null) && (required.Right != null))
            {
                if (fromRight)
                {
                    parent.Left = required.Right;
                }
                else
                {
                    parent.Right = required.Right;
                }

                return;
            }

            if ((required.Left != null) && (required.Right == null))
            {
                if (fromRight)
                {
                    parent.Left = required.Left;
                }
                else
                {
                    parent.Right = required.Left;
                }

                return;
            }

            if ((required.Left != null) && (required.Right != null))
            {
                slide = required.Left;
                if (slide.Right == null)
                {
                    if (fromRight)
                    {
                        parent.Left = required.Left;
                    }
                    else
                    {
                        parent.Right = required.Left;
                    }

                    required.Left.Right = required.Right;
                    return;
                }

                Node previous = slide;
                while (slide.Right != null)
                {
                    previous = slide;
                    slide = slide.Right;
                }

                previous.Right = slide.Left;
                slide.Left = required.Left;
                slide.Right = required.Right;
                if (fromRight)
                {
                    parent.Left = slide;
                }
                else
                {
                    parent.Right = slide;
                }

                return;
            }
        }

        private Node GetNode(int key)
        {
            if (this.root.Key == key)
            {
                return this.root;
            }

            Node i = this.root;
            while ((i.Left != null) || (i.Right != null))
            {
                if (i.Key == key)
                {
                    return i;
                }

                if (key < i.Key)
                {
                    if (i.Left != null)
                    {
                        i = i.Left;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (key > i.Key)
                {
                    if (i.Right != null)
                    {
                        i = i.Right;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            if (i.Key == key)
            {
                return i;
            }

            return null;
        }

        #region распечатка дерева рекурсивно в возрастающем и убывающем порядке

        /// <summary>
        /// prints tree to console in ascending/descending order
        /// </summary>
        /// <param name="order"></param>
        public void PrintTree(InOrder order)
        {
            if (this.root == null)
            {
                Console.WriteLine("the tree is empty");
                return;
            }
            else
            {
                if ((this.root.Right == null) && (this.root.Left == null))
                {
                    PrintNodes(this.root, InOrder.Ascending);
                    return;
                }

                if (order == InOrder.Ascending)
                {
                    if (this.root.Left != null)
                    {
                        PrintNodes(this.root.Left, InOrder.Ascending);
                    }

                    Console.Write(this.root.Value + " ");
                    if (this.root.Right != null)
                    {
                        PrintNodes(this.root.Right, InOrder.Ascending);
                    }
                }
                else if (order == InOrder.Descending)
                {
                    if (this.root.Right != null)
                    {
                        PrintNodes(this.root.Right, InOrder.Descending);
                    }

                    Console.WriteLine(this.root.Key + " ");
                    if (this.root.Left != null)
                    {
                        PrintNodes(this.root.Left, InOrder.Descending);
                    }
                }
            }
        }

        private void PrintNodes(Node node, InOrder order)
        {

            if (order == (int)InOrder.Ascending)
            {

                if (node.Left != null)
                {
                    PrintNodes(node.Left, InOrder.Ascending);
                }

                Console.Write(node.Value + " ");
                if (node.Right != null)
                {
                    PrintNodes(node.Right, InOrder.Ascending);
                }
            }
            else if (order == InOrder.Descending)
            {
                if (node.Right != null)
                {
                    PrintNodes(node.Right, InOrder.Descending);
                }

                Console.Write(node.Value + " ");
                if (node.Left != null)
                {
                    PrintNodes(node.Left, InOrder.Descending);
                }
            }
        }
        #endregion

        #region енумератор

        /// <summary>
        /// Supports a simple iteration over List<T>.
        /// </summary>
        public class TreeEnumenator : IEnumerator<T>
        {
            /// <summary>
            /// the class constructor
            /// </summary>
            /// <param name="tree"></param>
            public TreeEnumenator(BinaryTree<T> tree)
            {
                first = GetNodeWithMinimumKey(tree);
                stack = MarkWay(tree);
                Reset();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                current = Next();
                return (current != null);
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection
            /// </summary>
            public void Reset()
            {
                current = first;
            }

            /// <summary>
            /// Gets the current element in the collection
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// <summary>
            /// Gets the current element in the collection
            /// </summary>
            public T Current
            {
                get
                {
                    try
                    {
                        return current.Value;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose()
            {
            }

            private Node GetNodeWithMinimumKey(BinaryTree<T> tree)
            {
                if (tree.root == null)
                {
                    return null;
                }

                Node i = tree.root;
                while (i.Left != null)
                {
                    i = i.Left;
                }

                return i;
            }

            /// <summary>
            /// returns stack with node with smallest key in top
            /// this stack stores the nodes on which we were
            /// </summary>
            /// <param name="tree"></param>
            /// <returns></returns>
            private Stack<Node> MarkWay(BinaryTree<T> tree)
            {
                stack = new Stack<Node>();
                if (tree.root == null)
                {
                    return null;
                }

                Node i = tree.root;
                while (i.Left != null)
                {
                    stack.Push(i);
                    i = i.Left;
                }

                stack.Push(i);
                return stack;
            }

            /// <summary>
            /// returns a reference to the next node
            /// </summary>
            /// <returns></returns>
            private Node Next()
            {
                if (current == null)
                {
                    return null;
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    stack.Push(current);

                    while (current.Left != null)
                    {
                        current = current.Left;
                        stack.Push(current);
                    }
                }

                if (stack.Count == 0)
                {
                    return null;
                }

                return stack.Pop();
            }

            /// <summary>
            /// Enumerators are positioned before the first element
            /// until the first MoveNext() call.
            /// </summary>
            private Node first;
            private Node current;
            private Stack<Node> stack;
        }



        /// <summary>
        /// Implementation for the GetEnumerator method
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() => new TreeEnumenator(this);

        #endregion

        private Node root;

        private class Node
        {
            public Node(int key, T value)
            {
                this.Key = key;
                this.Value = value;
            }

            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; set; }
            public int Key { get; set; }
        }
    }
}