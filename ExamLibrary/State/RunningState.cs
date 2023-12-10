using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class RunningState : IState
    {
        private Player player;

        public RunningState(Player player)
        {
            this.player = player;
        }

        public void Enter()
        {
            Console.WriteLine("Entering running state ...\n");
        }

        public void Execute()
        {
            player.Stamina -= 10;

            Console.WriteLine(player.Stamina + " / " + player.MaxStamina);

            if (player.Stamina <= player.MaxStamina / 4)
                player.ChangeState(new RestState(player));
        }

        public void Exit()
        {
            Console.WriteLine("\nExiting running state ...");
            Console.ReadKey(); 
            Console.Clear();
        }
    }
}
