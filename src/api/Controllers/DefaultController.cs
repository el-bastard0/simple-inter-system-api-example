using ElBastard0.Api.Models;
using ElBastard0.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElBastard0.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IEntityService _entities;
        public DefaultController(IEntityService entities)
        {
            _entities = entities;
        }

        // GET: api/default
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return _entities.GetAsync();
        }

        // GET api/default/5
        [HttpGet("{id}")]
        public Task<Entity> Get(int id)
        {
            return _entities.GetAsync(id);
        }

        // POST api/default
        [HttpPost]
        public Task<Entity> Post([FromBody] Entity entity)
        {
            return _entities.AddAsync(entity);
        }

        // PUT api/default/5
        [HttpPut("{id}")]
        public Task<Entity> Put(int id, [FromBody] Entity entity)
        {
            return _entities.UpdateAsync(entity, id);
        }

        // DELETE api/default/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _entities.DeleteAsync(id);
        }
    }
}
