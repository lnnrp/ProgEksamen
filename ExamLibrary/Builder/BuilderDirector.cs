using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class BuilderDirector
    {
        private IFestivalBuilder builder;

        public BuilderDirector(IFestivalBuilder builder)
        {
            this.builder = builder;
        }

        public Festival ConstructFestival()
        {
            builder.BuildName();
            builder.BuildLocation();
            builder.BuildSetlist();
            builder.BuildStages();

            return builder.GetFestival();
        }
    }
}
