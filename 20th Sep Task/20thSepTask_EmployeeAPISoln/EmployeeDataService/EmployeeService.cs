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

        public IEnumerable<EmployeeDto> GetEmployee()
        {
            throw new System.NotImplementedException();
        }
    }
}
