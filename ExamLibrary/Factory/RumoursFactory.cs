using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class RumoursFactory : VinylFactory
    {
        public RumoursFactory()
        {
            Console.WriteLine("Factory producing 'Rumours' vinyl instantiated");
        }

        public override Vinyl CreateVinyl()
        {
            return new RumoursVinyl();
        }
    }
}
