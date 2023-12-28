using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace MyQueue
{
    /// <summary>
    /// Custom queue from array
    /// </summary>
    public class MyQueue<T> : IEnumerable<T>
    {
        private T[] elements = new T[4];

        private int index = 0;

        /// <summary>
        /// Adds new value to queue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            elements[index] = value;

            index++;

            // If the elements array is full, make a new one that is twice as big
            if(index == elements.Length)
            {
                T[] tmp = new T[elements.Length * 2];

                for(int i = 0; i < elements.Length; i++)
                {
                    tmp[i] = elements[i];
                }

                elements = tmp;
            }
        }

        /// <summary>
        /// Returns and removes value at beginning of queue
        /// </summary>
        /// <returns>Value at beginning of queue</returns>
        public T Dequeue()
        {
            // Saves value at beginning of queue
            T value = elements[0];

            // Removes first value in elements array and shifts all elements forward
            if (!value.Equals(default(T))) // Instead of null, as not all values can be null
            {
                // Starts at 1, and only goes through array as far as it's 'filled'
                for(int i = 1; i < index; i++)
                {
                    elements[i - 1] = elements[i];
                }

                index--;
            }

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
            elements = new T[4];
            index = 0;
        }

        public int Count()
        {
            return elements.Length;
        }

        public bool Contains(T value)
        {
            return elements.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i ++)
            {
                if (elements[i] !=  null && !elements[i].Equals(default(T))) // works for both ints and string
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
