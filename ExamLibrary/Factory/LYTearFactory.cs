using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class LYTearFactory : VinylFactory
    {
        public LYTearFactory()
        {
            Console.WriteLine("Factory producing 'Love Yourself: Tear' vinyl instantiated");
        }

        public override Vinyl CreateVinyl()
        {
            return new LYTearVinyl();
        }
    }
}
