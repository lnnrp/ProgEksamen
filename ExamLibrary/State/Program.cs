using State;

Console.WriteLine("Press space to progress ");

Player player = new Player();


while (true)
{
    Console.ReadKey(true); // Blocking call, no infinite loop
    player.ExecuteCurrentState();
}