using System.Threading.Tasks;
using WFM_API.Wfm_Core.ViewModel;

namespace WFM_API.Wfm_Core.Abstraction
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeesData();
    }
}
