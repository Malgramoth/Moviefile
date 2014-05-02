using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Moviefile.data.Model
{
    public class Actor
    {
        public Actor()
        {
            Movies = new Collection<Movie>();
        }

        public Guid Id { get; set; }
        public DateTime Dob { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
