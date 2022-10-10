﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM_API.Wfm_DomainModel
{
    public class SkillMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
        [Column("skillId")]
        public int SkillId { get; set; }
        public Skill Skills { get; set; }
    }
}
