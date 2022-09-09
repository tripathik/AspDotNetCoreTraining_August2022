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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetEmployeesData")]
        public async Task<IActionResult> GetEmployeesData()
        {
            try
            {
                var result = await _employeeService.GetAllEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetEmployeeByID")]
        public async Task<IActionResult> GetEmployeeByID(int Id)
        {
            try
            {
                var result = await _employeeService.GetAllEmployeeByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("InsertEmployee")]
        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.InsertEmployeeData(employeeDto);
                return Ok("Data has been inserted successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Route("UpdateEmployee")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.UpdateEmployeeData(employeeDto);
                return Ok("Data has been updated successfully!!!");
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
                await _employeeService.DeleteEmployeeData(id);
                return Ok("Data has been Deleted successfully!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
