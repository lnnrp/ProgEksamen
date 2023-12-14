using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCPServer
{
    public class Client
    {
        public string Name { get; set; }

        public Client(string? name)
        {
            this.Name = name;
        }
    }
}
