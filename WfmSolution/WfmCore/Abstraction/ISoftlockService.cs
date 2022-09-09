using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmCore.ViewModel;

namespace WfmCore.Abstraction
{
    public interface ISoftlockService
    {
        Task<List<SoftlockDto>> GetSoftlockData();
        Task<List<SoftlockDto>> GetSoftlockDataByID(int ID);
        Task InsertSoftlockData(SoftlockDto softlockDto);
        Task UpdateSoftlockData(SoftlockDto softlockDto);
        Task DeleteSoftlockData(int Id);
    }
}
