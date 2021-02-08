using System;
using System.Collections.Generic;

#nullable disable

namespace LeospaAPI.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
