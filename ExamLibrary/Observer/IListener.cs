using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IListener
    {
        /// <summary>
        /// Runs when even is triggered
        /// </summary>
        /// <param name="title"></param>
        void Notify(string title);
    }
}
