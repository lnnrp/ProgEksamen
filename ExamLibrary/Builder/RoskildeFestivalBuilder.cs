using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class RoskildeFestivalBuilder : IFestivalBuilder
    {
        private Festival roskilde;

        public RoskildeFestivalBuilder()
        {
            Reset();
        }

        public void BuildLocation()
        {
            roskilde.Location = "Roskilde, DK";
        }

        public void BuildName()
        {
            roskilde.Name = "Roskilde Festival";
        }

        public void BuildSetlist()
        {
            roskilde.AddElement("Act: Lydmor");
            roskilde.AddElement("Act: Thomas Helmig");
            roskilde.AddElement("Act: JADA");
        }

        public void BuildStages()
        {
            roskilde.AddElement("Stage: Orange");
            roskilde.AddElement("Stage: Apollo");
        }

        public Festival GetFestival()
        {
            return roskilde;
        }

        public void Reset()
        {
            roskilde = new Festival();
        }
    }
}
