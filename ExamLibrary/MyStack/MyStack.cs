using System;
using System.Collections;

namespace MyStack
{
    /// <summary>
    /// Custom stack from list
    /// </summary>
    public class MyStack<T> : IEnumerable<T>
    {
        List<T> elements = new List<T>();

        /// <summary>
        /// Adds new value to stack
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            elements.Add(value);
        }

        /// <summary>
        /// Returns and removes value on top of stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            // Saves last value in elements list
            T value = elements[Count() - 1];

            // Removes last value in elements list
            elements.RemoveAt(Count() - 1);
            return value;
        }

        public T Peek()
        {
            return elements[Count() - 1];
        }

        /// <summary>
        /// Clears stack
        /// </summary>
        public void Clear()
        {
            elements.Clear();
        }

        /// <summary>
        /// Returns amount of elements in stack
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return elements.Count;
        }

        /// <summary>
        /// Returns whether stack contains value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return elements.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Count(); i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
