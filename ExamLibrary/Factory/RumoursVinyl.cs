using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class RumoursVinyl : Vinyl
    {
        public RumoursVinyl()
        {
            NewVinyl();
        }

        public override void NewVinyl()
        {
            Console.WriteLine("Manufactured new 'Rumours' by Fleetwood Mac vinyl");
        }
    }
}
