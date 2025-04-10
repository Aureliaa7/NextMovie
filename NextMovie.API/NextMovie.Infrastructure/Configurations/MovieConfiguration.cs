using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextMovie.Application.Entities;

namespace NextMovie.Infrastructure.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Title)
               .HasMaxLength(300);

            //TODO: set max number of characters for MovieDbId
            builder.HasIndex(x => x.MovieDbId)
                .IsUnique();
        }
    }
}
