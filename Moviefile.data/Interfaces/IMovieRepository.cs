using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.data.Model;
using System.Linq.Expressions;


namespace Moviefile.data.Interfaces
{
    public interface IMovieRepository
    {
        /// <summary>
        /// get single movie by id
        /// </summary>
        /// <param name="id">Guid id</param>
        /// <returns></returns>
        Movie Get(Guid id);
        IQueryable<Movie> Get(Expression<Func<Movie, bool>> filter = null);
        Movie Create();
        Movie AddOrUpdate(Movie entity);
        void Remove(Movie entity);
        void Remove(Guid id);
        void SaveChanges();

    }
}
