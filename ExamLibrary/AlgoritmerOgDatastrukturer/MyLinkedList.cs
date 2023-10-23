using System;
using System.Collections;

namespace AlgoritmerOgDatastrukturer
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
