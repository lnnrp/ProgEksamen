using MyQueue;

MyQueue<int> intQueue = new MyQueue<int>();

// Put elements into intQueue
intQueue.Enqueue(2);
intQueue.Enqueue(6);
intQueue.Enqueue(48);
intQueue.Enqueue(93);

// Peek
Console.WriteLine("First element in queue: " + intQueue.Peek() + "\n");

// Foreach
foreach (int val in intQueue)
{
    Console.WriteLine(val.ToString());
}

// Prints count in console
Console.WriteLine("\nQueue has length of: " + intQueue.Count());

// Dequeue elements
intQueue.Dequeue();
intQueue.Dequeue();

// Peek
Console.WriteLine("First element in queue: " + intQueue.Peek());

// Contains
if (intQueue.Contains(48))
{
    Console.WriteLine("The element exists in the queue!");
}
if (!intQueue.Contains(3))
{
    Console.WriteLine("The element DOESN'T exists in the queue!");
}

// Clear and check
intQueue.Clear();
Console.WriteLine("Queue cleared!");
Console.WriteLine("Queue has length of: " + intQueue.Count());

Console.WriteLine("\n-----------\n");

MyQueue<string> stringQueue = new MyQueue<string>();

// Put elements into intQueue
stringQueue.Enqueue("link");
stringQueue.Enqueue("zelda");
stringQueue.Enqueue("ganon");
stringQueue.Enqueue("majora");

// Peek
Console.WriteLine("First element in queue: " + stringQueue.Peek() + "\n");

// Foreach
foreach (string val in stringQueue)
{
    Console.WriteLine(val);
}

// Prints count in console
Console.WriteLine("\nQueue has length of: " + stringQueue.Count());

// Dequeue elements
stringQueue.Dequeue();
stringQueue.Dequeue();

// Peek
Console.WriteLine("First element in queue: " + stringQueue.Peek());

// Contains
if (stringQueue.Contains("link"))
{
    Console.WriteLine("The element exists in the queue!");
}
if (!stringQueue.Contains("sonic"))
{
    Console.WriteLine("The element DOESN'T exists in the queue!");
}

// Clear and check
stringQueue.Clear();
Console.WriteLine("Queue cleared!");
Console.WriteLine("Queue has length of: " + stringQueue.Count());