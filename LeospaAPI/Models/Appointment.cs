using System;
using System.Collections.Generic;

#nullable disable

namespace LeospaAPI.Models
{
    public partial class Appointment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? ProcedureId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Notes { get; set; }
    }
}
