using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class ArtistEventEFConfiguration : IEntityTypeConfiguration<ArtistEvent>
    {
        public void Configure(EntityTypeBuilder<ArtistEvent> builder)
        {
            builder.HasKey(ae => new { ae.IdArtist, ae.IdEvent });

            builder
                .Property(ae => ae.PerformanceDate)
                .IsRequired();
        }
    }
}
