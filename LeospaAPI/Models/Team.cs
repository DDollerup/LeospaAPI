using System;
using System.Collections.Generic;

#nullable disable

namespace LeospaAPI.Models
{
    public partial class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
    }
}
