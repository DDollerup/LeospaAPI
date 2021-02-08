using System;
using System.Collections.Generic;

#nullable disable

namespace LeospaAPI.Models
{
    public partial class Hero
    {
        public long Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public string Ytlink { get; set; }
    }
}
