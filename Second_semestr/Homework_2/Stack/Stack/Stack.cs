using System;

namespace StackNamespace
{
    /// <summary>
    /// LIFO
    /// </summary>
    public class Stack : IStack
    {
        public void Push(int value)
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

        public int Top()
        {
            if (this.head == null)
            {
                throw new EmptyStackException("you are trying to access a non-existent object");
            }

            return this.head.Value;
        }

        public void Pop()
        {
            if (this.head == null)
            {
                throw new EmptyStackException("you are trying to access a non-existent object");
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

        private class StackElement
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="value"></param>
            public StackElement(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }
            public StackElement Next { get; set; }
        }

        private StackElement head;
    }
}