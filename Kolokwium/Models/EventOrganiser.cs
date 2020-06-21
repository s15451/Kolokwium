using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class EventOrganiser
    {
        [Key]
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        [Key]
        [ForeignKey("Organiser")]
        public int IdOrganiser { get; set; }
    }
}
