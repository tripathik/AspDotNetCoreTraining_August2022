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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        [Route("ReadUsersData")]
        public async Task<IActionResult> ReadUsersData()
        {
            try
            {
                var result = await _usersService.ReadUserData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertUsersData")]
        [HttpPost]
        public async Task<IActionResult> InsertUsersData(UsersDto usersDto)
        {
            try
            {
                await _usersService.InsertUserData(usersDto);
                return Ok("User data has been inserted successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
