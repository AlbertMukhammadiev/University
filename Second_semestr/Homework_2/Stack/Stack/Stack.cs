using IStackNamespace;
using MyException;
using System;

namespace StackNamespace
{
    public class Stack : IStack
    {
        private StackElement head;
        private class StackElement
        {
            public int Value { get; set; }
            public StackElement Next { get; set; }
        }

        public void Push(int value)
        {
            StackElement newElement = new StackElement();
            newElement.Value = value;
            if (this.head == null)
            {
                this.head = newElement;
                return;
            }
            newElement.Next = this.head;
            this.head = newElement;
        }

        public int GetValue() => this.head.Value;

        public void Pop()
        {
            if (this.head == null)
            {
                throw new MyNullReferenceException("you are trying to access a non-existent object");
            }

            this.head = this.head.Next;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

        public void PrintStack()
        {
            StackElement i = this.head;
            while (i != null)
            {
                Console.WriteLine(i.Value + " ");
                i = i.Next;
            }
        }
    }
}