using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moviefile.services.Interfaces
{
    public interface IMapping<T,E> 
        where T : class
        where E : class
    {

        T ToDTO(E entity);

        E FromDTO(T dto);

    }
}
