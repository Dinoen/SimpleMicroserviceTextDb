using Microsoft.AspNetCore.Mvc;
using SimpleMicroservice.Models;
using SimpleMicroservice.Services;

namespace SimpleMicroservice.Controllers
{
    [ApiController]
    [Route("api/Entries")]
    public class EntryController : ControllerBase
    {
        private readonly EntryService _entryService;

        public EntryController(EntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntries()
        {
            try
            {
                var entries = await _entryService.GetEntries();
                return Ok(entries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {
            try
            {
                var entry = await _entryService.GetEntry(id);
                return Ok(entry);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(Entry entry)
        {
            try
            {
                var result = await _entryService.AddEntry(entry);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
        }
    }
}
