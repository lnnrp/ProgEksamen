using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading
{
    /// <summary>
    /// This class uses the Lazy class that already exists in visual studio
    /// </summary>
    public class ImplementedLazyRecordStore
    {
        public Lazy<List<Vinyl>> vinyls; // The list that the boolean statement checks if it is null

        public List<Vinyl> LazyVinyls
        {
            get
            {
                return vinyls.Value;
            }
        }

        public ImplementedLazyRecordStore()
        {
            vinyls = new Lazy<List<Vinyl>>(() => LoadVinyls());
        }

        private List<Vinyl> LoadVinyls()
        {
            List<Vinyl> tmpVinyls = new List<Vinyl>()
            {
                new Vinyl("Love Yourself: Tear", 2018),
                new Vinyl("Rumours", 1977),
                new Vinyl("Black Holes and Revelations", 2006)
            };

            return tmpVinyls;
        }
    }
}
