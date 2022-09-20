using EmployeeDataCore.Abctractions;
using EmployeeDataCore.ViewModel;
using EmployeeDomainModel;
using EmployeeDomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDataContext _employeeDataContext;
        public EmployeeService(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var result = _employeeDataContext.Employees.Select(x => new EmployeeDto
            {
                Employee_Id = x.Employee_Id,
                Name = x.Name,
                Status = x.Status,
                Manager = x.Manager,
                WFM_Manager = x.WFM_Manager,
                Email = x.Email,
                Lockstatus = x.Lockstatus,
                Experience = x.Experience,

            }).ToList();
            return result;
        }

        public async Task InsertEmployeeData(EmployeeDto employeeDto)
        {

            Employee employees = new Employee()
            {
                Employee_Id = employeeDto.Employee_Id,
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Status = employeeDto.Status,
                Manager = employeeDto.Manager,
                WFM_Manager = employeeDto.WFM_Manager,
                Experience = employeeDto.Experience,
                Lockstatus = employeeDto.Lockstatus,
            };
            await _employeeDataContext.AddAsync(employees);
            _employeeDataContext.SaveChanges();
        }
    }
}
