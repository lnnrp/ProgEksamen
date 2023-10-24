using System.Xml.Linq;

Random rnd = new Random();
IComparer<int> comparer = Comparer<int>.Default;

// Instantiates int array and assigns random numbers throughout
int[] arrayToSort = new int[10];

for(int i = 0; i < arrayToSort.Length; i++) 
{
    arrayToSort[i] = rnd.Next(0, 101);
}

// Prints unsorted array
PrintArray(arrayToSort);

// Sorts array using Insertion sort
InsertionSort(arrayToSort);

// Prints sorted array
PrintArray(arrayToSort);


void InsertionSort(int[] elements)
{
    for (int i = 1; i < elements.Length; i++)
    {
        int val = elements[i];
        int pointer = i;

        // Runs through array and swaps if value to left is bigger 
        while (pointer > 0 && comparer.Compare(val, elements[pointer - 1]) > 0)
        {
            elements[pointer] = elements[pointer - 1];
            pointer--;
        }
        elements[pointer] = val;
    }
}

static void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}