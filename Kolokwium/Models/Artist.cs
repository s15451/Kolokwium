using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Artist
    {
        [Key]
        public int IdArtist { get; set; }

        public String Nickname { get; set; }
    }
}
