using System;

namespace SetNamespace
{
    /// <summary>
    /// class that implements ISet<T>
    /// </summary>
    public class Set<T> : ISet<T>
    {
        public void Add(T value)
        {
            SetElement newElement = new SetElement(value);
            if (this.head == null)
            {
                this.head = newElement;
                return;
            }

            newElement.Next = this.head;
            this.head = newElement;
        }

        public void Remove(T value)
        {
            if (this.head == null)
            {
                throw new EmptySetException("Set is empty");
            }

            if (this.head.Value.Equals(value))
            {
                this.head = this.head.Next;
                return;
            }

            SetElement i = this.head;
            while (i.Next != null)
            {
                if (i.Next.Value.Equals(value))
                {
                    i.Next = i.Next.Next;
                    return;
                }

                i = i.Next;
            }

            throw new NonExistentItemException("there is no element with the specified value in the Set");
        }

        public void Print()
        {
            if (this.head == null)
            {
                Console.WriteLine("Set is empty");
            }

            SetElement i = this.head;
            while (i != null)
            {
                Console.WriteLine(i.Value + " ");
                i = i.Next;
            }
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

            SetElement i = this.head;
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

        public void Intersect(Set<T> set)
        {
            var i = this.head;
            while (i != null)
            {
                if (!set.Contains(i.Value))
                {
                    this.Remove(i.Value);
                }

                i = i.Next;
            }
        }

        public void Unite(Set<T> set)
        {
            var i = set.head;
            while (i != null)
            {
                this.Add(i.Value);
                i = i.Next;
            }
        }

        private SetElement head;

        private class SetElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public SetElement(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public SetElement Next { get; set; }
        }
    }
}