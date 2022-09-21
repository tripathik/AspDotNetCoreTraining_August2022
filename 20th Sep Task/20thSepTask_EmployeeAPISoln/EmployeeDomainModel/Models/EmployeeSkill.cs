using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomainModel.Models
{
    public class EmployeeSkill
    {
        public int Employee_Id { get; set; }
        public Employee Employee { get; set; }
        public int Skill_Id { get; set; }
        public Skill Skill { get; set; }

    }
}
