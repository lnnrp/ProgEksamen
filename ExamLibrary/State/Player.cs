using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Player
    {
      
        private IState currentState;

        public int MaxStamina { get; } = 100;
        public int Stamina { get; set; }

        public Player()
        {
            ChangeState(new RunningState(this));
        }

        public void ExecuteCurrentState()
        {
            currentState.Execute();
        }

        public void ChangeState(IState nextState)
        {
            if(currentState != null)
                currentState.Exit();

            currentState = nextState;
            currentState.Enter();
        }

        
    }
}
