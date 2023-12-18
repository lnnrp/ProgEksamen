using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    public class VinylObjectPool : ObjectPool
    {
        protected override GameObject CreateObject()
        {
            return new Vinyl("Signed Vinyl"); // Creates a 'Signed Vinyl' if the inactive list is empty
        }
    }
}
