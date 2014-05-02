using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviefile.services.Model
{
    public class Actor
    {

        public Guid Id { get; set; }
        public DateTime Dob { get; set; }
        public string Name { get; set; }

    }
}
