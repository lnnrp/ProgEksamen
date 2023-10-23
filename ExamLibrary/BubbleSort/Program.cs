using System.Xml.Linq;

Random rnd = new Random();
IComparer<int> comparer = Comparer<int>.Default;


int[] arrayToSort = new int[10];

for(int i = 0; i < arrayToSort.Length; i++)
{
    arrayToSort[i] = rnd.Next(0, 101);
}

// Print unsorted array
PrintArray(arrayToSort);

// Perform BubbleSort
BubbleSort();

// Print sorted array
PrintArray(arrayToSort);

void BubbleSort()
{
    bool swapped;
    do
    {
        swapped = false;
        for (int i = 1; i < arrayToSort.Length - 1; i++)
        {
            // Skifter pladser hvis tallet til venstre er større end det til højre
            if (arrayToSort[i] > arrayToSort[i + 1])
            {
                (arrayToSort[i + 1], arrayToSort[i]) = (arrayToSort[i], arrayToSort[i + 1]);
                swapped = true;
            }
        }

    } while (swapped);
}

void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}