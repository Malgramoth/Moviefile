using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.services.Interfaces;
using MovieEntity = Moviefile.data.Model.Movie;
using MovieDTO = Moviefile.services.Model.Movie;
using Moviefile.data.Interfaces;
using System.Collections;

namespace Moviefile.services.Model.Mapping
{
    public class MovieMapping : IMapping<MovieDTO,MovieEntity>
    {
        

        public MovieDTO ToDTO(MovieEntity entity)
        {
            return new MovieDTO
            {
                CoverImage = entity.CoverImage,
                Genre = entity.Genre,
                Id = entity.Id,
                Release = entity.Release,
                Title = entity.Title
            };
        }

        public MovieEntity FromDTO(MovieDTO dto)
        {
            return new MovieEntity
            {
                CoverImage = dto.CoverImage,
                Genre = dto.Genre,
                Id = dto.Id,
                Release = dto.Release,
                Title = dto.Title
            };
        }
    }
}
