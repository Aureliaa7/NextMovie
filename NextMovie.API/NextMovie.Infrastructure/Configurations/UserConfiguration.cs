using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextMovie.Domain.Entities;

namespace NextMovie.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email)
                .HasMaxLength(50);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.FirstName)
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasMaxLength(80);

            // do not store the plain text password in the database
            builder.Ignore(x => x.Password);
        }
    }
}
