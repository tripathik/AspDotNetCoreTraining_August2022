//using EmployeeDataCore.Abctractions;
//using EmployeeDataCore.ViewModel;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;

//namespace _20thSepTask_EmployeeAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SkillController : ControllerBase
//    {
//        private readonly ISkillService _skillService;

//        public SkillController(ISkillService skillService)
//        {
//            _skillService = skillService;
//        }

//        [HttpGet]
//        [Route("GetAllSkillData")]
//        public async Task<IActionResult> GetAllSkillData()
//        {
//            try
//            {
//                var result = await _skillService.GetAllSkillData();
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }

//        [Route("InsertSkillData")]
//        [HttpPost]
//        public async Task<IActionResult> InsertSkillData(SkillDto skillDto)
//        {
//            try
//            {
//                await _skillService.InsertSkillData(skillDto);
//                return Ok("Data has been inserted successfully!!!");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }
//    }
//}

