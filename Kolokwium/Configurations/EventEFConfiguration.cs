using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations 
{
    public class EventEFConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => new { e.IdEvent });

            builder
                .Property(e => e.Name)
                .HasMaxLength(70)
                .IsRequired();

            builder
                .Property(e => e.StartDate)
                .IsRequired();

            builder
              .Property(e => e.EndDate)
              .IsRequired();
        }
    }
}
