using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.services.Interfaces;
using ActorEntity = Moviefile.data.Model.Actor;
using ActorDTO = Moviefile.services.Model.Actor;
using Moviefile.data.Interfaces;

namespace Moviefile.services.Model.Mapping
{
    public class ActorMapping : IMapping<ActorDTO,ActorEntity>
    {
    

        public ActorDTO ToDTO(ActorEntity entity)
        {
            return new ActorDTO
            {
                Id = entity.Id,
                Dob = entity.Dob,
                Name = entity.Name,
            };
 
        }

        public ActorEntity FromDTO(ActorDTO dto)
        {
            return new ActorEntity
            {
                Id = dto.Id,
                Dob = dto.Dob,
                Name = dto.Name
            };
        }
    }
}
