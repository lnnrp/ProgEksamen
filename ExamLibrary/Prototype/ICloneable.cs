using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public interface ICloneable
    {
        // Creates a shallow clone of the object
        VinylObject ShallowClone();

        // Creates a deep clone of the object
        VinylObject DeepClone();
    }
}
