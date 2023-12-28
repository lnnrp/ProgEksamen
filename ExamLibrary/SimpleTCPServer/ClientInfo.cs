using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCPServer
{
    public class ClientInfo
    {
        public string Name { get; set; }

        public ClientInfo(string name)
        {
            this.Name = name;
        }
    }
}
