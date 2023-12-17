using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /// <summary>
    /// Bastract object the factory creates, in place of ie GameObject in Monogame
    /// </summary>
    public abstract class Vinyl
    {
        public abstract void NewVinyl();
    }
}
