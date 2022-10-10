using WFM_API.Wfm_Core.ViewModel;

namespace WFM_API.Wfm_Core.Abstraction
{
    public interface ISoftLockService
    {
        Task<List<SoftLockDto>> GetSoftLocksData();

        string AddSoftLockData(SoftLockDto softLockDto);

        string UpdateSoftLockStatusData(int id, SoftLockDto softLockDto);
    }
}
