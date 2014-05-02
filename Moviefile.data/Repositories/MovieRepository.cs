 using Moviefile.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.data.Model;

namespace Moviefile.data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MoviefileContext _context = null;

        public MovieRepository(MoviefileContext context)
        {
                _context = context;
        }

        public Movie Get(Guid id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        public IQueryable<Movie> Get(System.Linq.Expressions.Expression<Func<Movie, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Movies.Where(filter);

            }
            return _context.Movies;
        }

        public Movie Create()
        {
            return AddOrUpdate(_context.Movies.Create());
        }

        public Movie AddOrUpdate(Movie entity)
        {
            Movie ret = null;
            if(_context.Entry<Movie>(entity).State == System.Data.Entity.EntityState.Detached)
            {
                if(_context.Movies.Where(M => M.Id == entity.Id).Any())
                {
                    ret = _context.Movies.Attach(entity);
                    _context.Entry<Movie>(ret).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    ret = _context.Movies.Add(entity);
                }
            }
            return ret;
        }

        public void Remove(Movie entity)
        {
            _context.Movies.Remove(entity);
        }

        public void Remove(Guid id)
        {
            Remove(Get(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
