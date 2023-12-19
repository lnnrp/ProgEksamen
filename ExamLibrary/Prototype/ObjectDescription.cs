using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Generic class for containing the description and name of an object
    /// </summary>
    public class ObjectDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ObjectDescription(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
