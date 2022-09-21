﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomainModel.Models
{
    public class Skill
    {
        public int Skill_Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public List<EmployeeSkill> EmployeeSkills { get;set; }
    }
}
