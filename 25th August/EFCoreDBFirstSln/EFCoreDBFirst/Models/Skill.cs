using System;
using System.Collections.Generic;

namespace EFCoreDBFirst.Models
{
    public partial class Skill
    {
        public decimal Skillid { get; set; }
        public string Name { get; set; } = null!;
    }
}
