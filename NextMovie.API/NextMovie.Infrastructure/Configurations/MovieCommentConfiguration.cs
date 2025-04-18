﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextMovie.Application.Entities;

namespace NextMovie.Infrastructure.Configurations
{
    internal class MovieCommentConfiguration : IEntityTypeConfiguration<MovieComment>
    {
        public void Configure(EntityTypeBuilder<MovieComment> builder)
        {
            builder.Property(x => x.Comment)
               .HasMaxLength(1000);

            builder.HasIndex(x => x.TmdbMovieId);
        }
    }
}
