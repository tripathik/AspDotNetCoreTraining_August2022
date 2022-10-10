using Microsoft.EntityFrameworkCore;
using WFM_API.Wfm_Core.Abstraction;
using WFM_API.Wfm_Core.ViewModel;
using WFM_API.Wfm_Data;

namespace WFM_API.Wfm_Service
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly EmployeeDataContext _dataContext;

        public EmployeeServices(EmployeeDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesData()
        {
            var employees = await _dataContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Where(s=>s.LockStatus == "not_requested").Select(x => new EmployeeDto
            {
                EmployeeID = x.EmployeeID,
                Email = x.Email,
                Name = x.Name,
                Manager = x.Manager,
                Experience = x.Experience,
                Wfm_Manager = x.Wfm_Manager,
                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
            }).ToListAsync();

            return employees;
        }
    }
}
