namespace PriorityQueueNamespace
{
    interface IPriorityQueue
    {
        /// <summary>
        /// adds a value to the queue with the specified priority
        /// </summary>
        /// <param name="value"></param>
        /// <param name="priority"></param>
        void Enqueue(char value, int priority);

        /// <summary>
        /// returns the element with the highest priority and removes it from the queue
        /// </summary>
        /// <returns></returns>
        char Dequeue();
    }
}
