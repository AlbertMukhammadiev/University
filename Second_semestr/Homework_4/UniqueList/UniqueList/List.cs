using System;
using MyException;

namespace ListNamespace
{
    public class List : IList
    {
        protected class ListElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public ListElement(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }
            public ListElement Next { get; set; }
        }

        protected ListElement head;

        public virtual void AddListElement(int value)
        {
            if (this.head == null)
            {
                this.head = new ListElement(value);
                return;
            }

            ListElement i = this.head;
            while (i.Next != null)
            {
                i = i.Next;
            }

            i.Next = new ListElement(value);
        }

        public void PrintList()
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

        public void DeleteListElement(int value)
        {
            if (this.head == null)
            {
                throw new EmptyListException("List is empty");
            }

            if (this.head.Value == value)
            {
                this.head = this.head.Next;
                return;
            }

            ListElement i = this.head;
            while (i.Next != null)
            {
                if (i.Next.Value == value)
                {
                    i.Next = i.Next.Next;
                    return;
                }

                i = i.Next;
            }

            throw new NonExistentItemException("there is no element with the specified value in the list");
        }

        public virtual void AddWithKeepingOrder(int value)
        {
            if (this.head == null)
            {
                this.head = new ListElement(value);
                return;
            }

            //Add to head
            if (this.head.Value >= value)
            {
                ListElement temp = this.head;
                this.head = new ListElement(value);
                this.head.Next = temp;
                return;
            }

            //Add to sort list
            ListElement i = this.head;
            while (i.Next != null)
            {
                if (i.Next.Value >= value)
                {
                    break;
                }

                i = i.Next;
            }

            ListElement newElement = new ListElement(value);
            newElement.Next = i.Next;
            i.Next = newElement;
        }

        public int GetIValue(int i)
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
    }
}