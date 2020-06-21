using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class ArtistEvent
    {
        [Key]
        [ForeignKey("Artist")]
        public int IdArtist { get; set; }

        [Key]
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
