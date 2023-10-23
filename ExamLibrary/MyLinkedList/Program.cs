// Create linked list
using MyLinkedList;

MyLinkedList<string> myLinkedList = new MyLinkedList<string>();

// Add elements
myLinkedList.AddLast("name");
myLinkedList.AddLast("is");
myLinkedList.AddLast("Jens");
myLinkedList.AddFirst("my");
myLinkedList.AddFirst("Hello");

// Print elements
PrintElements(myLinkedList);

// Remove first and last element
myLinkedList.RemoveFirst();
myLinkedList.RemoveLast();

// Print elements
PrintElements(myLinkedList);

Console.ReadKey(true);

static void PrintElements(MyLinkedList<string> linkedList)
{
    // Iterate through elements (MyLinkedList implements IEnumerable<T>)
    foreach (string item in linkedList)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine();
}