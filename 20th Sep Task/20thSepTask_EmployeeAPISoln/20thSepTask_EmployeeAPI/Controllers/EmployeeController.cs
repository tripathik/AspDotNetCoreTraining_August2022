using EmployeeDataCore.Abctractions;
using EmployeeDataCore.ViewModel;
using EmployeeDomainModel;
using EmployeeDomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _20thSepTask_EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDataContext _employeeDataContext;

        public EmployeeController(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {

            return await _employeeDataContext.Employees.Include(d => d.Skills).ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<ActionResult<Employee>>> Post(Employee emp)
        {
            try
            {
                Console.WriteLine(emp.Skills.Count);
                _employeeDataContext.Employees.Add(emp);

                await _employeeDataContext.SaveChangesAsync();
                return Ok(emp);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
