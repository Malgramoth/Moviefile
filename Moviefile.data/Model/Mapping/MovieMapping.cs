using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Moviefile.data.Model.Mapping
{
    public class MovieMapping : EntityTypeConfiguration<Movie>
    {
        public MovieMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Title).HasMaxLength(200).IsRequired();
            Property(x => x.Genre).HasMaxLength(40).IsRequired();
            Property(x => x.Release).IsRequired();
            Property(x => x.CoverImage).HasMaxLength(2000).IsRequired();
            HasMany(x => x.Actors).WithMany(x => x.Movies);
        }
    }
}
