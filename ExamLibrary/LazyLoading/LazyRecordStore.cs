using System;

namespace LazyLoading
{
    public class LazyRecordStore
    {
        public List<Vinyl> vinyls; // This is the list the bool statement in program checks

        public List<Vinyl> Vinyls 
        {
            get
            {
                if (vinyls == null)
                    LoadVinyls(); // Only loads the vinyls first time the list gets called (similar to singleton pattern)
                return vinyls;
            }
                
        }

        private void LoadVinyls()
        {
            vinyls = new List<Vinyl>()
            {
                new Vinyl("Love Yourself: Tear", 2018),
                new Vinyl("Rumours", 1977),
                new Vinyl("Black Holes and Revelations", 2006)
            };
        }
    }
}
