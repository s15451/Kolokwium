using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class EventOrganiserEFConfiguration : IEntityTypeConfiguration<EventOrganiser>
    {
        public void Configure(EntityTypeBuilder<EventOrganiser> builder)
        {
            builder.HasKey(eo => new { eo.IdEvent, eo.IdOrganiser });
        }
    }
}
