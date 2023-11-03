using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class GameManager
    {
        // Shorthand way of same function
        //public static GameManager Instance { get; } = new();

        // "Proper" way to write it
        // Only has "get" function, as instance only gets sets once, first time it's called
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameManager();

                return instance;
            }
        }

        // Private constructor so there can't exist multiple instances
        private GameManager()
        {

        }

        // Example property only available through GameManager instance
        public string State { get; set; } = "Pause State"; 
    }
}
