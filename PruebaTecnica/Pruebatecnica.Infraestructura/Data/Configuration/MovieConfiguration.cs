using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Description).HasMaxLength(1024);

            builder.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);


        }


    
    }
}
