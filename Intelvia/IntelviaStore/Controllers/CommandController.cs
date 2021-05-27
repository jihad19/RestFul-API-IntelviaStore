using IntelviaStore.Models;
using IntelviaStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICrudService<CommandModal> _CommandService;

        public CommandController(ICrudService<CommandModal> CommandService)
        {
            _CommandService = CommandService;
        }

        [HttpGet("GetCommandModals")]
        public async Task<IActionResult> GetCommandModals()
        {
            return Ok(await _CommandService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandModal>> GetCommandModals(int id)
        {
            return await _CommandService.Get(id);
        }

        [HttpPost("PostCommandModals")]
        public async Task<ActionResult<CommandModal>> PostCategoryModels([FromBody] CommandModal CommandModal)
        {
            var newCommandModal = await _CommandService.Create(CommandModal);
            return CreatedAtAction(nameof(GetCommandModals), new { id = newCommandModal.Id }, newCommandModal);
        }

        [HttpPut("PutCommandModals")]
        public async Task<ActionResult<CommandModal>> PutCommandModals(int id, [FromBody] CommandModal CommandModal)
        {
            if (id != CommandModal.Id)
            {
                return BadRequest();
            }
            await _CommandService.Update(CommandModal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandModal>> DeleteCommandModals(int id)
        {
            var CommandModalToDelete = await _CommandService.Get(id);
            if (CommandModalToDelete == null)
                return NotFound();

            await _CommandService.Delete(CommandModalToDelete.Id);
            return NoContent();
        }
    }
}
