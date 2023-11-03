using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class LollapaloozaBuilder : IFestivalBuilder
    {
        private Festival lollapalooza;

        public LollapaloozaBuilder()
        {
            Reset();
        }

        public void BuildLocation()
        {
            lollapalooza.Location = "Chicago, US";
        }

        public void BuildName()
        {
            lollapalooza.Name = "Lollapalooza";
        }

        public void BuildSetlist()
        {
            lollapalooza.AddElement("Act: j-hope");
            lollapalooza.AddElement("Act: Dua Lipa");
            lollapalooza.AddElement("Act: Green Day");

        }

        public void BuildStages()
        {
            lollapalooza.AddElement("Stage: Discord");
            lollapalooza.AddElement("Stage: Kidzapalooza");
        }

        public Festival GetFestival()
        {
            return lollapalooza;
        }

        public void Reset()
        {
            lollapalooza = new Festival();
        }
    }
}
