using Moviefile.services.Model;
using System.Collections.Generic;

namespace Moviefile.web.Models
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public IList<Actor> Actors { get; set; }
    }
}