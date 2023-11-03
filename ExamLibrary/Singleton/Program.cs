using Singleton;

Console.WriteLine("Current state: " + GameManager.Instance.State);

GameManager.Instance.State = "Menu State";

Console.WriteLine("\nCurrent state: " + GameManager.Instance.State);

Console.ReadKey();
