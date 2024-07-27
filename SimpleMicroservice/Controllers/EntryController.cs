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
            var entries = await _entryService.GetEntries();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry(int id)
        {
            var entry = await _entryService.GetEntry(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(Entry entry)
        {
            var result = await _entryService.AddEntry(entry);
            return Ok(result);
        }
    }

}
