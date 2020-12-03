using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {

        public void Configure(EntityTypeBuilder<Gender> builder)
        {

            builder.ToTable("Gender");

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50);
        }
    }
}
