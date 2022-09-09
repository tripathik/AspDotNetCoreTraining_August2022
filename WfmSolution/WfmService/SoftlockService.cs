using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmCore.Abstraction;
using WfmCore.ViewModel;
using WfmDataContext;
using WfmDomainModel.Models;

namespace WfmService
{
    public class SoftlockService : ISoftlockService
    {
        private readonly WfmDbContext _wfmDbContext;
        public SoftlockService(WfmDbContext wfmDbContext)
        {
            _wfmDbContext = wfmDbContext;
        }

        public async Task<List<SoftlockDto>> GetSoftlockData()
        {
            var result = _wfmDbContext.Softlock.Select(x => new SoftlockDto
            {
                Employee_id = x.Employee_id,
                LockId = x.LockId,
                Manager = x.Manager,
                ReqDate = x.ReqDate,
                Status = x.Status,
                RequestMessage = x.RequestMessage,
                Lastupdated = x.Lastupdated,
                WfmRemark = x.WfmRemark,
                ManagerStatus = x.ManagerStatus,
                MgrStatusComment = x.MgrStatusComment,
                MgrLastUpdate = x.MgrLastUpdate,
            }).ToList();
            return result;
        }

        public async Task<List<SoftlockDto>> GetSoftlockDataByID(int ID)
        {
            var data = GetSoftlockData().Result.Where(x => x.LockId == ID).ToList();
            return data;
        }

        public async Task InsertSoftlockData(SoftlockDto softlockDto)
        {

            softlock softlock = new softlock()
            {    
                Employee_id = softlockDto.Employee_id,
                Manager=softlockDto.Manager,
                ReqDate=softlockDto.ReqDate,
                Status=softlockDto.Status,
                Lastupdated=softlockDto.Lastupdated,
                RequestMessage=softlockDto.RequestMessage,  
                WfmRemark=softlockDto.WfmRemark,
                ManagerStatus=softlockDto.ManagerStatus,
                MgrLastUpdate=softlockDto.MgrLastUpdate,
                MgrStatusComment=softlockDto.MgrStatusComment,

            };
            await _wfmDbContext.AddAsync(softlock);
            _wfmDbContext.SaveChanges();
        }

        public async Task UpdateSoftlockData(SoftlockDto softlockDto)
        {
            var softlockData = _wfmDbContext.Softlock.Where(x => x.LockId == softlockDto.LockId).FirstOrDefault();
            if (softlockData != null)
            {
                softlockData.Employee_id = softlockDto.Employee_id;
                softlockData.Manager = softlockDto.Manager; 
                softlockData.ReqDate = softlockDto.ReqDate; 
                softlockData.Status = softlockDto.Status;
                softlockData.Lastupdated = softlockDto.Lastupdated;
                softlockData.RequestMessage = softlockDto.RequestMessage;
                softlockData.WfmRemark = softlockDto.WfmRemark;
                softlockData.ManagerStatus = softlockDto.ManagerStatus;
                softlockData.MgrLastUpdate = softlockDto.MgrLastUpdate;
                softlockData.MgrStatusComment = softlockDto.MgrStatusComment;
            }
            _wfmDbContext.SaveChanges();
        }

        public async Task DeleteSoftlockData(int Id)
        {
            var softlockData = _wfmDbContext.Softlock.Where(x => x.LockId == Id).FirstOrDefault();
            if (softlockData != null)
            {
                _wfmDbContext.Remove(softlockData);
                _wfmDbContext.SaveChanges();
            }
        }
    }
}
