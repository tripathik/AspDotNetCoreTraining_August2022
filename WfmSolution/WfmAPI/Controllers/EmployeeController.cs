using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WfmDomainModel.Models;
using WfmService.Abstraction;

namespace WfmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("GetAllEmployee")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = _employeeService.GetAllEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("GetAllEmployeeById")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeById(int id)
        {
            try
            {
                var result = _employeeService.GetEmployee(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertEmployeeData")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployeeData([FromBody] employees employees)
        {
            try
            {
                _employeeService.InsertEmployeeData(employees);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("UpdateEmployeeData")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeData([FromBody] employees employees)
        {
            try
            {
                _employeeService.UpdateEmployee(employees);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("DeleteEmployeeData")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeData(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
