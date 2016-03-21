using System;
using IListNamespace;

namespace ListNamespace
{
    class List : IList
    {
        private class ListElement
        {
            public string Value { get; set; }
            public ListElement Next { get; set; }
        }

        private ListElement head;

        public void AddListElement(string value)
        {
            ListElement newElement = new ListElement();
            newElement.Value = value;

            if (this.head == null)
            {
                this.head = newElement;
                return;
            }

            ListElement i = this.head;
            while (i.Next != null)
            {
                i = i.Next;
            }
            i.Next = newElement;
        }

        public void PrintList()
        {
            Console.Write("	");
            if (this.head == null)
            {
                Console.WriteLine("-List is empty");
            }
            else
            {
                ListElement i = this.head;
                while (i != null)
                {
                    Console.Write(i.Value + " ");
                    i = i.Next;
                }
                Console.WriteLine();
            }
        }

        public bool IsExist(string value)
        {
            ListElement i = this.head;
            while (i.Next != null)
            {
                if (i.Value == value)
                {
                    return true;
                }
                i = i.Next;
            }
            if (i.Value == value)
            {
                return true;
            }
            return false;
        }

        public void DeleteElement(string value)
        {
            if (this.head == null)
            {
                Console.WriteLine("	-List is empty");
                return;
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
        }
    }
}