using Microsoft.EntityFrameworkCore;
using WfmDataContext;
using WfmDomainModel.Models;
using WfmService.Abstraction;

namespace WfmService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WfmDbContext _wfmDbContext;
        private DbSet<employees> _employeesData;

        public EmployeeService(WfmDbContext wfmDbContext, DbSet<employees> employeesData)
        {
            _wfmDbContext = wfmDbContext;
            _employeesData = _wfmDbContext.Set<employees>();
        }

        public employees GetEmployee(int id)
        {
            return _employeesData.SingleOrDefault(e => e.Employee_id == id);
        }
        public IEnumerable<employees> GetAllEmployees()
        {
            return _employeesData.AsEnumerable();
        }
        public void InsertEmployeeData(employees employees)
        {
            _wfmDbContext.Entry(employees).State = EntityState.Added;
            _wfmDbContext.SaveChanges();
        }
        public void UpdateEmployee(employees employees)
        {
            _wfmDbContext.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            employees employees = GetEmployee(id);
            _employeesData.Remove(employees);
            _wfmDbContext.SaveChanges();
        } 
    }
}
