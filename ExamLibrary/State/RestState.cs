using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class RestState : IState
    {
        private Player player;

        public RestState(Player player)
        {
            this.player = player;
        }

        public void Enter()
        {
            Console.WriteLine("Entering rest state ...\n");
        }

        public void Execute()
        {
            player.Stamina += 10;

            Console.WriteLine(player.Stamina + " / " + player.MaxStamina);


            if (player.Stamina >= player.MaxStamina)
            {
                player.Stamina = player.MaxStamina;

                player.ChangeState(new RunningState(player));
            }
  

        }

        public void Exit()
        {
            Console.WriteLine("\nExiting rest state ...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
