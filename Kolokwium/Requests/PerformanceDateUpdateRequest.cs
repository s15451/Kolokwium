﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Requests
{
    public class PerformanceDateUpdateRequest
    {
        [Required]
        public int IdArtist { get; set; }
        [Required]
        public int IdEvent { get; set; }

        public DateTime PerformanceDate { get; set; }
    }
}
