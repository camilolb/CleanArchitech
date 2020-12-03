using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class ContryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.ContryId);

            builder.ToTable("Country");

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50);
        
        }
    }
}
