using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmerOgDatastrukturer
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] elements;
        private int index = 0;

        private IComparer<T> comparer = Comparer<T>.Default;

        public MyList()
        {
            elements = new T[4];
        }

        public void Add(T element)
        {
            //If array is half full
            if (index == elements.Length / 2)
            {
                //Saves current array to temporary one
                T[] tmp = elements.ToArray();

                //Overrides old array to make a new one twice as long
                elements = new T[elements.Length * 2];

                //Adds all elements from old array into new one
                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    elements[i] = tmp[i];
                }
            }

            //Adds element parameter into the array on current index
            elements[index] = element;
            index++;
        }

        public void Remove(T element)
        {
            //Linear search through the array
            for (int i = 0; i < elements.Length - 1; i++)
            {
                //Checks if the current index is equal to the element parameter
                if (elements[i].Equals(element))
                {
                    //Runs through all elements equal to the current index
                    for (int y = i; y < elements.Length - 1; y++)
                    {
                        //Sets the index value to its default
                        elements[y] = elements[y + 1];
                        elements[y + 1] = default(T);
                    }

                    //Removes index count to account for the removal
                    index--;
                    break;
                }
            }
        }

        public void Clear()
        {
            index = 0;

            for (int i = 0; i < elements.Length - 1; i++)
            {
                elements[i] = default(T);
            }
        }

        public void Sort()
        {
            Array.Sort(elements, 0, index);
        }

        /// <summary>
        /// Sorts the list with the Insertion algorithm
        /// </summary>
        /// <param name="list"></param>
        public void InsertionSort()
        {

            for (int i = 1; i < elements.Length; i++)
            {
                T val = elements[i];
                int pointer = i;

                while (pointer > 0 && comparer.Compare(val, elements[pointer - 1]) > 0)
                {
                    elements[pointer] = elements[pointer - 1];
                    pointer--;
                }
                elements[pointer] = val;
            }
        }

        /// <summary>
        /// Sorts the list using the BubbleMethod
        /// </summary>
        public void BubbleSort()
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < elements.Length; i++)
                {
                    if (comparer.Compare(elements[i - 1], elements[i]) < 0)
                    {
                        (elements[i - 1], elements[i]) = (elements[i], elements[i - 1]);
                        swapped = true;
                    }
                }

            } while (swapped);
        }

        /// <summary>
        /// Sorts the list using the QuickSort algorithem
        /// </summary>
        public void QuickSort()
        {
            //idk how :(
        }




        public IEnumerator<T> GetEnumerator()
        {
            //Runs through the array until it reaches current index count
            int indexO = 0;
            while (indexO < index)
            {
                yield return elements[indexO];
                indexO++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
