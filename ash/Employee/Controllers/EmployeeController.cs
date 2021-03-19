using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHEmployee.Data;
using ASHEmployee.Repository;
using ASHEmployee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASHEmployee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee,EmployeeRepository>
    {
        private readonly EmployeeRepository _repo;
        public EmployeeController(EmployeeRepository repo):base(repo)
        {
           _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employee>>> Post()
        {
            return await _repo.GetAll();
        }


        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, Employee emp)
        {
            if (id != emp.Id || ( !emp.CanHaveExpenses && emp.MaxExpenseAmount>0))
            {
                return BadRequest();
            }
            await _repo.Update(emp);

            return Ok();
        }


        [HttpPost]
        public new async Task<ActionResult<Employee>> Post(Employee emp)
        {
            if (!emp.CanHaveExpenses && emp.MaxExpenseAmount > 0)
            {
                return BadRequest();
            }
            await _repo.Add(emp);

            return CreatedAtAction("Get", new { id = emp.Id }, emp);
        }
    }
}
