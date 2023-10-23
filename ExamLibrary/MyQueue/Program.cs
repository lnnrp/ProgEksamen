using MyQueue;

Console.WriteLine("\nCustom Queue");
MyQueue<int> myQueue = new MyQueue<int>();

myQueue.Enqueue(2);
myQueue.Enqueue(1);
myQueue.Enqueue(0);

Console.WriteLine("Count: " + myQueue.Count());

Console.WriteLine("Dequeue: " + myQueue.Dequeue());
Console.WriteLine("Count: " + myQueue.Count());

Console.WriteLine("Peek: " + myQueue.Peek());
Console.WriteLine("Count: " + myQueue.Count());

Console.ReadLine();