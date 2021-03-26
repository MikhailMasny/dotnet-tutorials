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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var parentModel =
                await _parentRepositoryManager
                    .GetAll()
                    .Include(parentModel => parentModel.ChildModels)
                    .FirstOrDefaultAsync(parentModel => parentModel.Id == id);

            return parentModel is null
                ? NotFound()
                : Ok(parentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParentRequest model)
        {
            var parentModel = new ParentModel
            {
                StringVar = model.StringVar,
            };

            await _parentRepositoryManager.CreateAsync(parentModel);
            await _parentRepositoryManager.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ParentRequest model)
        {
            var parentModel =
                await _parentRepositoryManager
                    .GetEntityWithoutTrackingAsync(parentModel => parentModel.Id == id);

            if (parentModel is null)
            {
                return NotFound();
            }

            parentModel.StringVar = model.StringVar;
            _parentRepositoryManager.Update(parentModel);
            await _parentRepositoryManager.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var parentModel =
                await _parentRepositoryManager
                    .GetEntityWithoutTrackingAsync(parentModel => parentModel.Id == id);

            if (parentModel is null)
            {
                return NotFound();
            }

            _parentRepositoryManager.Delete(parentModel);
            await _parentRepositoryManager.SaveChangesAsync();

            return NoContent();
        }
    }

    public class ParentRequest
    {
        public string StringVar { get; set; }
    }
}
