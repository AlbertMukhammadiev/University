using ListNamespace;
using MyException;

namespace UniqueListNamespace
{
    public class UniqueList : List
    {
        /// <summary>
        /// duplicate values are ignored
        /// </summary>
        /// <param name="value"></param>
        public override void AddListElement(int value)
        {
            if (this.head == null)
            {
                this.head = new ListElement(value); ;
                return;
            }

            if (this.head.Value == value)
            {
                throw new DuplicateValuesException("the list contains the given value");
            }

            ListElement i = this.head;
            while (i.Next != null)
            {
                if (i.Value == value)
                {
                    throw new DuplicateValuesException("the list contains the given value");
                }

                i = i.Next;
            }
            i.Next = new ListElement(value);
        }

        /// <summary>
        /// duplicate values are ignored
        /// </summary>
        /// <param name="value"></param>
        public override void AddWithKeepingOrder(int value)
        {
            if (this.head == null)
            {
                this.head = new ListElement(value);
                return;
            }

            if (this.head.Value == value)
            {
                throw new DuplicateValuesException("the list contains the given value");
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
                if (i.Value == value)
                {
                    throw new DuplicateValuesException("the list contains the given value");
                }

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
    }
}
