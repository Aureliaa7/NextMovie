using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextMovie.Domain.Entities;

namespace NextMovie.Infrastructure.Configurations
{
    internal class MovieCommentConfiguration : IEntityTypeConfiguration<MovieComment>
    {
        public void Configure(EntityTypeBuilder<MovieComment> builder)
        {
            builder.Property(x => x.Comment)
               .HasMaxLength(1000);
        }
    }
}
