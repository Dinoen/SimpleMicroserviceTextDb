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
            try
            {
                _context.Entries.Add(entry);
                await _context.SaveChangesAsync();
                return "Entry added successfully.";
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the entry.", ex);
            }
        }

        public async Task<List<Entry>> GetEntries()
        {
            try
            {
                return await _context.Entries.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error happened while getting entries.", ex);
            }
        }

        public async Task<Entry> GetEntry(int id)
        {
            try
            {
                var entry = await _context.Entries.FindAsync(id);
                if (entry == null)
                {
                    throw new KeyNotFoundException("Entry not found.");
                }
                return entry;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error happened while getting the entry. Id looked for: {id} ", ex);
            }
        }
    }
}