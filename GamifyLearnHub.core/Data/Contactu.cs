using System;
using System.Collections.Generic;

namespace GamifyLearnHub.Core.Data
{
    public partial class Contactu
    {
        public decimal Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Phonenumber { get; set; }
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? Messagereceived { get; set; }
    }
}
