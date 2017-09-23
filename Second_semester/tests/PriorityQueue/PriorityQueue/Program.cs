using System;
using PriorityQueueNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Enqueue('o', 4);
            queue.Enqueue('y', 8);
            queue.Enqueue('p', 1);
            queue.Enqueue('i', 3);
            queue.Enqueue('r', 2);
            queue.Enqueue('i', 6);
            queue.Enqueue('r', 5);
            queue.Enqueue('t', 7);
            queue.PrintQueue();
            Console.Write(queue.Dequeue());
        }
    }
}
