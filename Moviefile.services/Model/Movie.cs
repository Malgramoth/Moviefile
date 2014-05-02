using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moviefile.services.Model
{
    public class Movie
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string Genre { get; set; }
        public string CoverImage { get; set; }

    }
}
