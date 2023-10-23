using MyList;

List<int> list = new List<int>();
list.Add(1);
list.Add(0);
list.Add(0);
list.Add(1);
list.Add(2);
list.Remove(1);
list.RemoveAt(list.Count() - 1);
list.ForEach(x => Console.Write(x + " "));

Console.WriteLine();

MyList<int> myList = new MyList<int>();
myList.Add(1);
myList.Add(0);
myList.Add(0);
myList.Add(1);
myList.Add(2);
myList.Remove(1);
myList.RemoveAt(myList.Count() - 1);

foreach (int number in myList)
{
    Console.Write(number + " ");
}

myList.Clear();
Console.WriteLine("\nCount: " + myList.Count());

Console.ReadLine();