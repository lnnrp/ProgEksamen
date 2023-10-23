using System;
using System.Collections;

namespace MyQueue
{
    /// <summary>
    /// Custom queue from list
    /// </summary>
    public class MyQueue<T> : IEnumerable<T>
    {
        List<T> elements = new List<T>();

        /// <summary>
        /// Adds new value to queue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            elements.Add(value);
        }

        /// <summary>
        /// Returns and removes value at beginning of queue
        /// </summary>
        /// <returns>Value at beginning of queue</returns>
        public T Dequeue()
        {
            // Saves value at beginning of queue
            T value = elements[0];

            // Removes first value in elements list
            elements.RemoveAt(0);

            return value;
        }

        /// <summary>
        /// Returns value at the beginning of queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return elements[0];
        }

        /// <summary>
        /// Clears queue
        /// </summary>
        public void Clear()
        {
            elements.Clear();
        }

        public int Count()
        {
            return elements.Count;
        }

        public bool Contains(T value)
        {
            return elements.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                yield return elements[i];
            }
        }

        // Non generic - for backwards compatibility
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
