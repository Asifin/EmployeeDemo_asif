using EmployeeWeb.Model;
using EmployeeWeb.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo) 
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else { return NotFound(); }
        }
        [HttpGet("GetById/{EmpID}")]
        public async Task<IActionResult> GetById(string EmpID)
        {
            var _list = await repo.GetById(EmpID);
            if (_list != null)
            {
                return Ok(_list);
            }
            else { return NotFound(); }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]EmployeeModel employee)
        {
            var _result = await repo.Create(employee);
            return Ok(_result);
           
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EmployeeModel employee,string EmpID)
        {
            var _result = await repo.Update(employee,EmpID);
            return Ok(_result);

        }
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete( string EmpID)
        {
            var _result = await repo.Delete( EmpID);
            return Ok(_result);

        }
    }
}
