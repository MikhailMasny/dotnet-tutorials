using Masny.DotNet.Crud.Interfaces;
using Masny.DotNet.Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly IRepositoryManager<ParentModel> _parentRepositoryManager;
        private readonly IRepositoryManager<ChildModel> _childRepositoryManager;

        public CrudController(
            IRepositoryManager<ParentModel> parentRepositoryManager,
            IRepositoryManager<ChildModel> childRepositoryManager)
        {
            _parentRepositoryManager = parentRepositoryManager ?? throw new ArgumentNullException(nameof(parentRepositoryManager));
            _childRepositoryManager = childRepositoryManager ?? throw new ArgumentNullException(nameof(childRepositoryManager));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parentModels =
                await _parentRepositoryManager.GetAll()
                    .Include(parentModel => parentModel.ChildModels)
                    .ToListAsync();

            return Ok(parentModels);
        }



        // GET api/<CrudController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrudController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CrudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CrudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
