using System;

namespace ListNamespace
{
    class List
    {
        private class ListElement
        {
            private int aValue { get; set; }
            public int Value
            {
                get
                {
                    return aValue;
                }

                set
                {
                    this.aValue = value;
                }
            }

            public ListElement Next { get; set; }

        }

        private ListElement head;

        public void addListElement(int value)
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

        public void printList()
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

        void deleteElement(int value)
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

//void addNewElement(Value value, List* list)
//{
//    if (!list->head)
//    {
//        list->head = new ListElement;
//        list->head->value = value;
//        return;
//    }
//    else
//    {
//        if (list->head->value == value)
//        {
//            std::cout << "	This element is already present in the list" << std::endl;
//            return;
//        }

//        //Add to head
//        if (list->head->value > value)
//        {
//            Position temp = list->head;
//            list->head = new ListElement;
//            list->head->value = value;
//            list->head->next = temp;
//            return;
//        }

//        //Add to sort list
//        Position i = list->head;
//        while (i->next)
//        {
//            if (i->next->value == value)
//            {
//                std::cout << "	This element is already present in the list" << std::endl;
//                return;
//            }

//            if (i->next->value > value)
//            {
//                break;
//            }
//            i = i->next;
//        }

//        Position newElement = new ListElement;
//        newElement->value = value;
//        newElement->next = i->next;
//        i->next = newElement;
//    }
//}