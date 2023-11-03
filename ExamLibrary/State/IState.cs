using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface IState
    {
        /// <summary>
        /// Gets called when entering state
        /// </summary>
        void Enter();

        /// <summary>
        /// Executes the states function (update loop)
        /// </summary>
        void Execute();

        /// <summary>
        /// Called before changing to another state
        /// </summary>
        void Exit();
    }
}
