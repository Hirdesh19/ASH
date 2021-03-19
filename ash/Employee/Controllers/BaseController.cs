using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASHEmployee.Data;
using ASHEmployee.Models;


namespace ASHEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity,TRepository> : ControllerBase
        where TEntity: class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _repository.Update(entity);

            return Ok();
        }

    
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(TEntity entity)
        {
            await _repository.Add(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
           var entity= await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

    }
}
