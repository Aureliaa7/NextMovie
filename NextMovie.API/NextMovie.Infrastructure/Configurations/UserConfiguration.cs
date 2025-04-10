using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextMovie.Application.Entities;

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
                .HasMaxLength(60);

            builder.Property(x => x.LastName)
                .HasMaxLength(50);

            // do not store the plain text password in the database
            builder.Ignore(x => x.Password);

            builder.Property(b => b.PasswordHash)
            .IsRequired();

            builder.Property(b => b.PasswordSalt)
               .IsRequired();
        }
    }
}
