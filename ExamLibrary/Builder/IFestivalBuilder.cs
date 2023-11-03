using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IFestivalBuilder
    {
        void Reset();

        /// <summary>
        /// Name of festival
        /// </summary>
        void BuildName();

        /// <summary>
        /// City/country festival takes place in
        /// </summary>
        void BuildLocation();

        /// <summary>
        /// Different stages the acts perform on
        /// </summary>
        void BuildStages();

        /// <summary>
        /// The music acts that partake in festival
        /// </summary>
        void BuildSetlist();

        Festival GetFestival();


    }
}
