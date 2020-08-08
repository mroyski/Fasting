using Fasting.Data;
using Fasting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fasting.Services
{
    public class AchievedItemService
    {
        private readonly ApplicationDbContext _context;

        public AchievedItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rhythm[]> GetIncompleteItemsAsync()
        {
            var items = await _context.Rhythm
                .Where(x => x.Achieved == false)
                .ToArrayAsync();
            return items;
        }

        public async Task<bool> MarkDoneAsync(int id)
        {
            var item = await _context.Rhythm
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.Achieved = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }

        public async Task<bool> MarkNotDoneAsync(int id)
        {
            var item = await _context.Rhythm
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.Achieved = false;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
