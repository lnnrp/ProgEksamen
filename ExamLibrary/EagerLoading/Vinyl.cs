using System;

namespace EagerLoading
{
    public class Vinyl
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public Vinyl(string title, int year)
        {
            this.Title = title;
            this.Year = year;
        }
    }
}
