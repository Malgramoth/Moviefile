using System.Collections.Generic;
using Moviefile.services.Model;

namespace Moviefile.web.Models
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }
        public IList<Movie> Movies { get; set; }
    } 
    
}