using System;

namespace ListNamespace
{
    class List
    {
        private class ListElement
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

        private ListElement head;

        public void AddListElement(int value)
        {
            ListElement newElement = new ListElement(value);
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
            if (this.head == null)
            {
                Console.WriteLine("-List is empty");
                return;
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

        public void AddWithKeepingOrder(int value)
        {
            if (this.head == null)
            {
                this.head = new ListElement(value);
                return;
            }

            if (this.head.Value == value)
            {
                Console.WriteLine("	This element is already present in the list");
                return;
            }

            //Add to head
            if (this.head.Value > value)
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
                if (i.Next.Value == value)
                {
                    Console.WriteLine("	This element is already present in the list");
                    return;
                }

                if (i.Next.Value > value)
                {
                    break;
                }

                i = i.Next;
            }

            ListElement newElement = new ListElement(value);
            newElement.Next = i.Next;
            i.Next = newElement;
        }
    }
}