using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Moviefile.data.Model.Mapping
{
    public class ActorMapping : EntityTypeConfiguration<Actor>
    {
        public ActorMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Name).HasMaxLength(200).IsRequired();
            Property(x => x.Dob).IsRequired();

            HasMany(x => x.Movies).WithMany(x => x.Actors);
            
        }

    }
}
