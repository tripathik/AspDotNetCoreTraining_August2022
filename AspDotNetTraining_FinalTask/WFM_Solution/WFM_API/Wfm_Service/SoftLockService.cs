using Microsoft.EntityFrameworkCore;
using WFM_API.Wfm_Core.Abstraction;
using WFM_API.Wfm_Core.ViewModel;
using WFM_API.Wfm_Data;
using WFM_API.Wfm_DomainModel;

namespace WFM_API.Wfm_Service
{
    public class SoftLockService : ISoftLockService
    {
        private readonly EmployeeDataContext _dataContext;

        public SoftLockService(EmployeeDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string AddSoftLockData(SoftLockDto softLockDto)
        {
            if (softLockDto != null)
            {
                _dataContext.Add(new SoftLock
                {
                    EmployeeId = softLockDto.EmployeeId,
                    Manager = softLockDto.Manager,
                    ManagerStatus = softLockDto.ManagerStatus,
                    RequestDate = softLockDto.RequestDate,
                    RequestMessage = softLockDto.RequestMessage,
                });
                _dataContext.SaveChanges();
                return "Data has been added successfully!!!";

            }
            else
            {
                return "No record has been found!!!";
            }
        }

        public Task<List<SoftLockDto>> GetSoftLocksData()
        {
            var softlock = _dataContext.SoftLocks.Include(s=>s.Employees).Where(s => s.ManagerStatus == "awaiting_confirmation")
                .Select(s => new SoftLockDto
                {
                    LockId = s.LockId,
                    EmployeeName = s.Employees.Name,
                    EmployeeId = s.EmployeeId,
                    Manager = s.Manager,
                    ManagerStatus = s.ManagerStatus,
                    RequestMessage = s.RequestMessage,
                    RequestDate = s.RequestDate,
                });

            return Task.FromResult(softlock.ToList());
                                                       
        }

        public string UpdateSoftLockStatusData(int id, SoftLockDto softLockDto)
        {
            var softLock = _dataContext.SoftLocks.Include(s => s.Employees).FirstOrDefault(s => s.LockId == id);
            if (softLock != null)
            {
                if (softLockDto.ManagerStatus == "approved")
                {
                    softLock.ManagerStatus = softLockDto.ManagerStatus;
                    softLock.Employees.LockStatus = "locked";

                }
                else
                {
                    softLock.ManagerStatus = softLockDto.ManagerStatus;
                    softLock.Employees.LockStatus = "not_requested";
                }
                _dataContext.Update(softLock);
                _dataContext.SaveChanges();

                return "Data has been updated successfullyu";

            }
            else
            {
                return "No record has been found!!!!";
            }
        }
    }
}
