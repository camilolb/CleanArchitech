using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            
                builder.ToTable("Actor");

                builder.Property(e => e.Date).HasColumnType("datetime");

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            
        }
    }
}
