using System;

namespace StackNamespace
{
    /// <summary>
    /// LIFO
    /// </summary>
    public class Stack<T>// : IStack<T>
    {
        public void Push(T value)
        {
            StackElement newElement = new StackElement(value);
            if (this.head == null)
            {
                this.head = newElement;
                return;
            }

            newElement.Next = this.head;
            this.head = newElement;
        }

        public T Top()
        {
            if (this.head == null)
            {
                throw new Exception();
                //throw new EmptyStackException("you are trying to access a non-existent object");
            }

            return this.head.Value;
        }

        public void Pop()
        {
            if (this.head == null)
            {
                throw new Exception();
                //throw new EmptyStackException("you are trying to access a non-existent object");
            }

            this.head = this.head.Next;
        }

        public bool IsEmpty() => this.head == null;

        public void PrintStack()
        {
            if (this.head == null)
            {
                Console.WriteLine("Stack is empty");
            }

            StackElement i = this.head;
            while (i != null)
            {
                Console.WriteLine(i.Value + " ");
                i = i.Next;
            }
        }

        public void Clear()
        {
            this.head = null;
        }

        private class StackElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public StackElement(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public StackElement Next { get; set; }
        }

        private StackElement head;
    }
}