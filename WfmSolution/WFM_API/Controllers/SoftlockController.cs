using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WfmCore.Abstraction;
using WfmCore.ViewModel;

namespace WFM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftlockController : ControllerBase
    {
        private readonly ISoftlockService _softlockService;

        public SoftlockController(ISoftlockService softlockService)
        {
            _softlockService = softlockService;
        }

        [HttpGet]
        [Route("GetSoftlockData")]
        public async Task<IActionResult> GetSoftlockData()
        {
            try
            {
                var result = await _softlockService.GetSoftlockData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetSoftlockDataByID")]
        public async Task<IActionResult> GetSoftlockDataByID(int Id)
        {
            try
            {
                var result = await _softlockService.GetSoftlockDataByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertSoftlockData")]
        [HttpPost]
        public async Task<IActionResult> InsertSoftlockData(SoftlockDto softlockDto)
        {
            try
            {
                await _softlockService.InsertSoftlockData(softlockDto);
                return Ok("Data has been inserted successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("UpdateSoftlock")]
        [HttpPut]
        public async Task<IActionResult> UpdateSoftlock(SoftlockDto softlockDto)
        {
            try
            {
                await _softlockService.UpdateSoftlockData(softlockDto);
                return Ok("Data has been updated successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("DeleteSoftlockData")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSoftlockData(int id)
        {
            try
            {
                await _softlockService.DeleteSoftlockData(id);
                return Ok("Data has been Deleted successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
