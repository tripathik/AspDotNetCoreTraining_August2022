using WfmCore.ViewModel;
using WfmDataContext;
using WfmDomainModel.Models;
using WfmCore.Abstraction;

namespace WfmService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WfmDbContext _wfmDbContext;
        public EmployeeService(WfmDbContext wfmDbContext)
        {
            _wfmDbContext = wfmDbContext;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var result= _wfmDbContext.Employees.Select(x => new EmployeeDto
            {
                Employee_id = x.Employee_id,
                Name = x.Name,
                Status = x.Status,
                Manager = x.Manager,
                Wfm_manager = x.Wfm_manager,
                Email = x.Email,
                Lockstatus = x.Lockstatus,
                Experience = x.Experience,
                Profile_id = x.Profile_id,

            }).ToList();
            return result;
        }

        public async Task<List<EmployeeDto>> GetAllEmployeeByID(int ID)
        {
            //var result = _wfmDbContext.Employees.Where(x=>x.Employee_id==ID).ToList();
            var data = GetAllEmployees().Result.Where(x => x.Employee_id == ID).ToList();
            return data;
        }

        public async Task InsertEmployeeData(EmployeeDto employeeDto)
        {

            employees employees = new employees()
            {
                Employee_id = employeeDto.Employee_id,
                Name= employeeDto.Name,
                Email= employeeDto.Email,
                Status = employeeDto.Status,
                Manager= employeeDto.Manager,
                Wfm_manager= employeeDto.Wfm_manager,
                Experience= employeeDto.Experience,
                Lockstatus= employeeDto.Lockstatus,
                Profile_id= employeeDto.Profile_id,
            };
            await _wfmDbContext.AddAsync(employees);
            _wfmDbContext.SaveChanges();
        }

        public async Task UpdateEmployeeData(EmployeeDto employeeDto)
        {
            var employeeData = _wfmDbContext.Employees.Where(x => x.Employee_id == employeeDto.Employee_id).FirstOrDefault();
            if(employeeData!=null)
            {
                employeeData.Name = employeeDto.Name;
                employeeData.Email = employeeDto.Email; 
                employeeData.Status = employeeDto.Status;
                employeeData.Manager = employeeDto.Manager;
                employeeData.Wfm_manager = employeeDto.Wfm_manager;
                employeeData.Experience = employeeDto.Experience;
                employeeData.Lockstatus = employeeDto.Lockstatus;
                employeeData.Profile_id = employeeDto.Profile_id;
                _wfmDbContext.Update(employeeData);
            }
            _wfmDbContext.SaveChanges();
        }

        public async Task DeleteEmployeeData(int Id)
        {
            var employeeData = _wfmDbContext.Employees.Where(x => x.Employee_id == Id).FirstOrDefault();
            if (employeeData != null)
            {
                _wfmDbContext.Remove(employeeData);
                _wfmDbContext.SaveChanges();
            }
        }
    }
}