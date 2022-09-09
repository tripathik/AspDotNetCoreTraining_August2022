using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmCore.ViewModel;
using WfmDomainModel.Models;

namespace WfmCore.Abstraction
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<List<EmployeeDto>> GetAllEmployeeByID(int ID);
        Task InsertEmployeeData(EmployeeDto employeeDto);
        Task UpdateEmployeeData(EmployeeDto employeeDto);
        Task DeleteEmployeeData(int Id);
    }
}
