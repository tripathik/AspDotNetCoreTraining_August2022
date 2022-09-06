﻿using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class User
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Email { get; set; }
    }
}
