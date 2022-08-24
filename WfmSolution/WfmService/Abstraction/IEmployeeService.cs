using WfmDomainModel.Models;

namespace WfmService.Abstraction
{
    public interface IEmployeeService
    {
        void InsertEmployeeData(employees employees);
        IEnumerable<employees> GetAllEmployees();
        employees GetEmployee(int id);
        void DeleteEmployee(int id);
        void UpdateEmployee(employees employees);
    }
}
