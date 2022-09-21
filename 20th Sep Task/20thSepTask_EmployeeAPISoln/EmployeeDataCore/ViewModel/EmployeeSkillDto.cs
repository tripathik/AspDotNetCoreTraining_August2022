using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataCore.ViewModel
{
    public class EmployeeSkillDto
    {
        public int Employee_Id { get; set; }
        public EmployeeDto Employee { get; set; }
        public int Skill_Id { get; set; }
        public SkillDto Skill { get; set; }
    }
}
