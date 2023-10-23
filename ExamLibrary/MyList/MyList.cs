using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyList
{
    public class MyList<T> : IEnumerable<T>
    {
        //Array of values
        private T[] elements;

        private IComparer<T> comparer = Comparer<T>.Default;

        public MyList()
        {
            elements = new T[0];
        }

        public void Add(T value)
        {
            //Temporary array with +1 size
            T[] tmp = new T[Count() + 1];

            // Moves values in elements to tmp array
            for(int i = 0; i < Count(); i++)
            {
                tmp[i] = elements[i];
            }

            // Adds new value to end of tmp array
            tmp[tmp.Length - 1] = value;

            // Overrides element array with tmp array
            elements = tmp;
        }


        public void Remove(T value)
        {
            // Check if value exists in array
            if (!Contains(value))
                return;

            // Create new temporary array with -1 size
            T[] tmp = new T[Count() - 1];

            // Counter used for countering offset from skipped value that is removed
            int counter = 0;

            // Only remove first occurence of value
            bool removed = false;

            // Iterate through current ellemtns and skip value to be removec
            for (int i = 0; i < Count(); i++)
            {
                // Removes element that matches value
                if (value.Equals(elements[i]) && !removed)
                {
                    removed = true;
                    continue;
                }

                // Transfer element to tmp array and increase counter
                tmp[counter] = elements[i];
                counter++;
            }

            // Override elements array with tmp array
            elements = tmp;
        }

        /// <summary>
        /// Removes element at given index
        /// </summary>
        /// <param name="index">The index in the list to remove</param>
        public void RemoveAt(int index)
        {
            // Checks if index is within element array size
            if (Count() - 1 < index)
                return;

            // Temporary array with +1 size 
            T[] tmp = new T[Count() - 1];

            // Counter used for countering offset from skipped value that is removed
            int counter = 0;

            // Iterate through current elements and skip value to be removed
            for (int i = 0; i < Count(); i++)
            {
                // Skips value to be removed
                if (i == index)
                    continue;

                // Transfer elements to tmp array and increase counter
                tmp[counter] = elements[i];
                counter++;
            }

            // Override array with tmp array
            elements = tmp;
        }

        public bool Contains(T value)
        {
            // Iterates through elements and returns true if matchiung value is found
            for (int i = 0; i < Count(); i++)
                if (value.Equals(elements[i]))
                    return true;

            // Value not found in list
            return false;
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            elements = new T[0];
        }

        /// <summary>
        /// The amount of values in List
        /// </summary>
        /// <returns>List length</returns>
        private int Count()
        {
            return elements.Length;
        }

        /// <summary>
        /// Sorts the list elements with default array sort
        /// </summary>
        public void Sort()
        {
            Array.Sort(elements, 0, Count());
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
            for (int i = 0; i < Count(); i++)
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
