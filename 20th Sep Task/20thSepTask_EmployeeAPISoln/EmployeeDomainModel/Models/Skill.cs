using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomainModel.Models
{
    public class Skill
    {
        public Skill()
        {
            Employees = new HashSet<Employee>();
        }
        public int Skill_Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
