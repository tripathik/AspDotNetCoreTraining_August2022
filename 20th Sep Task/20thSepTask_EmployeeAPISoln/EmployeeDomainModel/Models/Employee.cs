﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomainModel.Models
{
    public class Employee
    {
        public Employee()
        {
            Skills = new HashSet<Skill>();
        }
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string WFM_Manager { get; set; }
        public string Email { get; set; }
        public string Lockstatus { get; set; }
        public decimal Experience { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

    }
}
