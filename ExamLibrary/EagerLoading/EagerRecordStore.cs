using System;

namespace EagerLoading
{
    public class EagerRecordStore
    {
        public List<Vinyl> vinyls; // This is the list the bool statement in program checks

        public List<Vinyl> EagerVinyls { get => vinyls; set => vinyls = value; }

        public EagerRecordStore()
        {
            LoadVinyls(); // Loads the vinyls right away, as soon as the record store is instantiated
        }

        private void LoadVinyls()
        {
            vinyls = new List<Vinyl>()
            {
                new Vinyl("Love Yourself: Tear", 2018),
                new Vinyl("Rumors", 1977),
                new Vinyl("Black Holes and Revelations", 2006)
            };
        }
    }
}
