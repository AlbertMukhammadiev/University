using System;

namespace ListNamespace
{
    /// <summary>
    /// singly linked list
    /// </summary>
    public class List
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

        public void Add(string value)
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
                Console.Write("List is empty");
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

        public void Remove(string value)
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

        public string GetValue(int i)
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

        public bool Contains(string value)
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

        private int size;
        private ListElement head;
        private ListElement tail;

        private class ListElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public ListElement(string value)
            {
                this.Value = value;
            }

            public string Value { get; set; }
            public ListElement Next { get; set; }
        }
    }
}