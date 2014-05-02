using Moviefile.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.data;
using Moviefile.data.Model;

namespace Moviefile.data.Repositories
{
    public class ActorRepository : IActorRepository


    {
        private MoviefileContext _context = null;

        public ActorRepository(MoviefileContext context)
        {
            _context = context;
        }


        public Actor Get(Guid id)
        {
            return _context.Actors.Find(id);
        }

        public IQueryable<Actor> Get(System.Linq.Expressions.Expression<Func<Actor, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Actors.Where(filter);

            }
            return _context.Actors;
        }

        public Actor Create()
        {
            return Add(_context.Actors.Create());
        }

        public Actor Add(Actor entity)
        {
            return _context.Actors.Add(entity);
        }

        public void Remove(Actor entity)
        {
            _context.Actors.Remove(entity);
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
