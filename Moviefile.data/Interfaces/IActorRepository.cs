using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moviefile.data.Model;
using System.Linq.Expressions;

namespace Moviefile.data.Interfaces
{
    public interface IActorRepository
    {
        /// <summary>
        /// get single actor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Actor Get(Guid id);
        IQueryable<Actor> Get(Expression<Func<Actor, bool>> filter = null);
        Actor Create();
        Actor Add(Actor entity);
        void Remove(Actor entity);
        void Remove(Guid id);
        void SaveChanges();

    }
}
