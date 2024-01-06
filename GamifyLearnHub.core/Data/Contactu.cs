using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Contactu
    {
        public decimal Id { get; set; }
        public string? Name { get; set; }
        public decimal? Phonenumber { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
        public DateTime? Messagereceived { get; set; }
    }
}
