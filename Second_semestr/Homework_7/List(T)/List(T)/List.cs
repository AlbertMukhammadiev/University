using System;
using System.Collections;
using System.Collections.Generic;

namespace ListNamespace
{
    /// <summary>
    /// singly linked list
    /// </summary>
    public class List<T> : IList<T>, IEnumerable<T>
    {
        /// <summary>
        /// gets the number of elements contained in the List
        /// </summary>
        public int Count
        {
            get
            {
                return size;
            }
        }

        public void Add(T value)
        {
            var newElement = new ListElement(value);
            if (this.head == null)
            {
                this.head = newElement;
                this.tail = newElement;
                ++this.size;
                return;
            }

            this.tail.Next = newElement;
            this.tail = newElement;
            ++this.size;
        }

        public void Print()
        {
            if (this.head == null)
            {
                throw new EmptyListException("List is empty");
            }

            Console.Write("	");
            ListElement i = this.head;
            while (i != null)
            {
                Console.Write(i.Value + " ");
                i = i.Next;
            }
            Console.WriteLine();
        }

        public void Remove(T value)
        {
            if (this.head == null)
            {
                throw new EmptyListException("List is empty");
            }

            if (this.head.Value.Equals(value))
            {
                this.head = this.head.Next;
                if (size == 1)
                {
                    this.tail = null;
                }

                --this.size;
                return;
            }

            ListElement i = this.head;
            while (i.Next != null)
            {
                if (i.Next.Value.Equals(value))
                {
                    i.Next = i.Next.Next;
                    if (i.Next == null)
                    {
                        this.tail = i;
                    }

                    --this.size;
                    return;
                }

                i = i.Next;
            }

            throw new NonExistentItemException("there is no element with the specified value in the list");
        }

        public T GetValue(int i)
        {
            ListElement j = this.head;
            while ((i != 0) & (j != null))
            {
                j = j.Next;
                --i;
            }

            if (i != 0)
            {
                throw new NonExistentItemException("the size of the list smaller than the sequence number of the element, or sequence number is a negative number");
            }

            return j.Value;
        }

        public bool Contains(T value)
        {
            if (this.head == null)
            {
                return false;
            }

            if (this.head.Value.Equals(value))
            {
                return true;
            }

            ListElement i = this.head;
            while (i.Next != null)
            {

                i = i.Next;
                if (i.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Supports a simple iteration over List<T>.
        /// </summary>
        public class ListEnumerator : IEnumerator<T>
        {
            private ListElement current;

            /// <summary>
            /// Enumerators are positioned before the first element
            /// until the first MoveNext() call.
            /// </summary>
            private ListElement hat;

            /// <summary>
            /// the class constructor
            /// </summary>
            /// <param name="list"></param>
            public ListEnumerator(List<T> list)
            {
                hat = new ListElement(list.head.Value);
                hat.Next = list.head;
                Reset();
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                current = current.Next;
                return (current != null);
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection
            /// </summary>
            public void Reset()
            {
                current = hat;
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

            public void  Dispose()
                {
                }
        }

        /// <summary>
        /// Implementation for the GetEnumerator method
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns></returns>
        public ListEnumerator GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        private int size;
        private ListElement head;
        private ListElement tail;

        private class ListElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public ListElement(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public ListElement Next { get; set; }
        }
    }
}