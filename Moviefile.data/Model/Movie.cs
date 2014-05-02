using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Moviefile.data.Model
{
    public class Movie
    {
        public Movie()
        {
            Actors = new Collection<Actor>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string Genre { get; set; }
        public string CoverImage { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

    }
}
