﻿using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Plan
    {
        public Plan()
        {
            Programs = new HashSet<Program>();
        }

        public decimal Planid { get; set; }
        public string Planname { get; set; } = null!;

        public virtual ICollection<Program> Programs { get; set; }
    }
}