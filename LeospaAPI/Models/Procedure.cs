﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LeospaAPI.Models
{
    public partial class Procedure
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}