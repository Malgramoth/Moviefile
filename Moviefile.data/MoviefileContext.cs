using Moviefile.data.Model;
using System.Data.Entity;

namespace Moviefile.data
{

    public class MoviefileContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Model.Mapping.ActorMapping());
            modelBuilder.Configurations.Add(new Model.Mapping.MovieMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
 //insert into Actors(Id,Name,Dob)
 //   values (NEWID(),'Bob Smith','1978-05-23')
}
