using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Festival
    {
        public List<string> FestivalElements { get; set; } = new List<string>();
        public string Name { get; set; }

        public string Location { get; set; }

        public void AddElement(string element)
        {
            FestivalElements.Add(element);
        }

        public void ShowAllElements()
        {
            Console.WriteLine($"The {Name} contains the following elements: ");
            foreach(string element in FestivalElements)
            {
                Console.WriteLine(element);
            }
        }
    }
}
