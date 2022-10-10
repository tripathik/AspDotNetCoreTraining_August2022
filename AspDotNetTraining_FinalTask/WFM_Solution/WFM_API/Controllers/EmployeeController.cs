using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WFM_API.Wfm_Core.Abstraction;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get All Employess Information
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult> Employees()
        {
            try
            {

                var employeeList = await _employeeService.GetAllEmployeesData();
                return new OkObjectResult(employeeList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
