using System;
using System.Collections;

namespace MyLinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public Node<T> AddFirst(T value)
        {
            Node<T> n = new Node<T>(value);

            if (First != null)
            {
                First.Previous = n;
                n.Next = First;
                First = n;
            }
            else
            {
                First = n;
                Last = n;
            }

            return n;
        }

        public Node<T> AddLast(T value)
        {
            Node<T> n = new Node<T>(value);

            if (First != null)
            {
                n.Previous = Last;
                Last.Next = n;
                Last = n;
            }
            else
            {
                First = n;
                Last = n;
            }

            return n;
        }

        /// <summary>
        /// Removes first node in list
        /// </summary>
        public void RemoveFirst()
        {
            // Set new first node
            First = First.Next;

            // Remove reference to previous node
            First.Previous = null;
        }

        /// <summary>
        /// Removes last node in list
        /// </summary>
        public void RemoveLast()
        {
            // Set new first node
            First = First.Previous;

            // Remove reference to previous node
            First.Next = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
