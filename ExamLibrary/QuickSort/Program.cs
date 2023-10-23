using System.Net.NetworkInformation;
using System.Transactions;

Random rnd = new Random();

int[] arrayToSort = new int[10];

// Insert random numbers into array
for(int i = 0; i < arrayToSort.Length; i++)
{
    arrayToSort[i] = rnd.Next(0, 101);
}

// Print unsorted numbers
PrintArray(arrayToSort);

// Execute quick sort algorithm
QuickSort(arrayToSort, 0, arrayToSort.Length - 1);

// Print sorted numbers
PrintArray(arrayToSort);

static void QuickSort(int[] array, int left, int right)
{ 
    // Makes sure original left/right values doesn't get changed (used for recursive recall)
    int l = left;
    int r = right;

    // Middle value is set as pivot 
    int pivot = array[(left + right) / 2];

    // When right pointer is to the left of left pointer, the partition is done
    while(l <= r)
    {
        // Move left pointer to the right until finding a number larger than the pivot
        while (array[l] < pivot)
            l++;

        // Move right pointer to the left until finding a number smaller than the pivot
        while (array[r] > pivot)
            r--;

        // Make sure left is still to the left of right
        if (l <= r)
        {
            (array[l], array[r]) = (array[r], array[l]);

            l++;
            r--;
        }
    }

    // Sort pile to the left of pivot if old left pointer is to the right of new right pointer
    if (left < r)
        QuickSort(array, left, r);

    // Sort pile to the right of pivot if new left pointer is to the left of old right pointer
    if (l < right)
        QuickSort(array, l, right);
}

static void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}