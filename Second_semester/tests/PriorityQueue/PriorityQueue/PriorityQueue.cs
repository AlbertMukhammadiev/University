using System;
using MyException;

namespace PriorityQueueNamespace
{
    public class PriorityQueue : IPriorityQueue
    {
        private class QueueItem
        {
            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="priority"></param>
            /// <param name="Value"></param>
            public QueueItem(char value, int priority)
            {
                this.Priority = priority;
                this.Value = value;
            }

            public char Value { get; set; }
            public int Priority { get; set; }
            public QueueItem Next { get; set; }
        }

        QueueItem first;
        QueueItem last;

        public void Enqueue(char value, int priority)
        {
            QueueItem newItem = new QueueItem(value, priority);
            if (this.last == null)
            {
                this.last = newItem;
                this.first = newItem;
                return;
            }

            if (this.first.Priority < priority)
            {
                this.first = newItem;
            }

            if (this.last.Priority >= priority)
            {
                QueueItem temp = this.last;
                this.last = new QueueItem(value, priority);
                this.last.Next = temp;
                return;
            }

            QueueItem i = this.last;
            while (i.Next != null)
            {
                if (i.Next.Priority >= priority)
                {
                    break;
                }

                i = i.Next;
            }

            QueueItem newElement = new QueueItem(value, priority);
            newElement.Next = i.Next;
            i.Next = newElement;
        }

        public char Dequeue()
        {
            if (this.last == null)
            {
                throw new EmptyQueueException("you are trying to access a non-existent object");
            }

            QueueItem i = this.last;
            QueueItem j = this.last;
            while (i.Next != null)
            {
                j = i;
                i = i.Next;
            }
            
            var value = this.first.Value;
            this.first = j;
            j.Next = null;
            return value;
        }

        public void PrintQueue()
        {
            if (this.last == null)
            {
                throw new EmptyQueueException("Queue is empty");
            }

            QueueItem i = this.last;
            while (i != null)
            {
                Console.WriteLine(i.Value + " ");
                i = i.Next;
            }
        }
    }
}
