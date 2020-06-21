using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class OrganiserEFConfiguration : IEntityTypeConfiguration<Organiser>
    {
        public void Configure(EntityTypeBuilder<Organiser> builder)
        {
            builder.HasKey(o => new { o.IdOrganiser });

            builder
                .Property(o => o.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
