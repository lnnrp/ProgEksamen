using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class VinylObject : ICloneable
    {
        /// <summary>
        /// Is a value type, used to show difference in shallow/deep copy and how they handle types
        /// </summary>
        public int ObjectNumber { get; set; }

        /// <summary>
        /// Is a reference type, used to show difference in shallow/deep clone and how they handle types
        /// </summary>
        public ObjectDescription ObjectDescription { get; set; }

        public VinylObject(int objectNumber, string objectName, string objectDescription)
        {
            ObjectNumber = objectNumber;
            ObjectDescription = new ObjectDescription(objectName, objectDescription);
        }

        /// <summary>
        /// Makes a shallow clone - handles reference/value types differently <para></para>
        /// Makes a copy of all value types, meaning they can be changed in the clone without manipulating values in other clones <para></para>
        /// With reference types, like ObjectDescription being a class/object, there aren't new instances, and thus they refer to the original clone <para></para>
        /// </summary>
        /// <returns></returns>
        public VinylObject ShallowClone()
        {
            return (VinylObject)this.MemberwiseClone();
        }
        
        /// <summary>
        /// Makes a deep clone - doesn't have references to the original object <para></para>
        /// New instances of the class gets made instead of copying them
        /// </summary>
        /// <returns></returns>
        public VinylObject DeepClone()
        {
            VinylObject deepClone = (VinylObject)this.MemberwiseClone();
            deepClone.ObjectDescription = new ObjectDescription(ObjectDescription.Name, ObjectDescription.Description);
            return deepClone;
        }
    }
}
