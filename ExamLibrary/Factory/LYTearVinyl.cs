using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class LYTearVinyl : Vinyl
    {
        public LYTearVinyl()
        {
            NewVinyl();
        }

        public override void NewVinyl()
        {
            Console.WriteLine("Manufactured new 'Love Yourself: Tear' by BTS vinyl");
        }
    }
}
