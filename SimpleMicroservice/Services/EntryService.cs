using Microsoft.EntityFrameworkCore;
using SimpleMicroservice.Models;

namespace SimpleMicroservice.Services
{
    public class EntryService
    {
        private readonly ApplicationDbContext _context;

        public EntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddEntry(Entry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry), "Entry is null.");
            }

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return "Entry added successfully.";
        }

        public async Task<List<Entry>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        public async Task<Entry> GetEntry(int id)
        {
            return await _context.Entries.FindAsync(id);
        }
    }
}