using MyStack;
using System.Collections.Generic;

Console.WriteLine("\nCustom Stack");
MyStack<int> myStack = new MyStack<int>();

myStack.Push(2);
myStack.Push(1);
myStack.Push(0);

Console.WriteLine("Count: " + myStack.Count());

Console.WriteLine("Pop: " + myStack.Pop());
Console.WriteLine("Count: " + myStack.Count());

Console.WriteLine("Peek: " + myStack.Peek());
Console.WriteLine("Count: " + myStack.Count());

Console.ReadLine();