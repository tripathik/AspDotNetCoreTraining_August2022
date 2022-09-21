using EmployeeDataCore.Abctractions;
using EmployeeDataCore.ViewModel;
using EmployeeDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataService
{
    public class SkillService : ISkillService
    {
        //private readonly EmployeeDataContext _employeeDataContext;
        //public SkillService(EmployeeDataContext employeeDataContext)
        //{
        //    _employeeDataContext = employeeDataContext;
        //}

        //public async Task<List<SkillDto>> GetAllSkillData()
        //{
        //    var result = _employeeDataContext.Skills.Select(x => new SkillDto
        //    {
        //        Skill_Id = x.Skill_Id,
        //        Name = x.Name,

        //    }).ToList();
        //    return result;
        //}

        //public async Task InsertSkillData(SkillDto skillDto)
        //{

        //    SkillDto skills = new SkillDto()
        //    {
        //        Skill_Id=skillDto.Skill_Id,
        //        Name=skillDto.Name,
        //    };
        //    await _employeeDataContext.AddAsync(skills);
        //    _employeeDataContext.SaveChanges();
        //}
    }
}
