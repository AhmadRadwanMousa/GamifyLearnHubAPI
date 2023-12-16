﻿using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal? Userid { get; set; }
        public string? Status { get; set; }
        public string? Review { get; set; }

        public virtual User? User { get; set; }
    }
}
