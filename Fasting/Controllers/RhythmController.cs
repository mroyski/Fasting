using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fasting.Data;
using Fasting.Models;
using Fasting.Services;
using Microsoft.AspNetCore.Localization;

namespace Fasting.Controllers
{
    public class RhythmController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AchievedItemService _achievedItemService;

        public RhythmController(ApplicationDbContext context, AchievedItemService achievedItemService)
        {
            _context = context;
            _achievedItemService = achievedItemService;
        }

        // GET: Rhythm
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rhythm.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> MarkDone(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                return RedirectToAction("Index");
            }

            var successful = await _achievedItemService.MarkDoneAsync(id);
            if (!successful)
            {
                await _achievedItemService.MarkNotDoneAsync(id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Rhythm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rhythm = await _context.Rhythm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rhythm == null)
            {
                return NotFound();
            }

            return View(rhythm);
        }

        // GET: Rhythm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rhythm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ratio,StartTime,EndTime,Achieved")] Rhythm rhythm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rhythm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rhythm);
        }

        // GET: Rhythm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rhythm = await _context.Rhythm.FindAsync(id);
            if (rhythm == null)
            {
                return NotFound();
            }
            return View(rhythm);
        }

        // POST: Rhythm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ratio,StartTime,EndTime,Achieved")] Rhythm rhythm)
        {
            if (id != rhythm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rhythm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RhythmExists(rhythm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rhythm);
        }

        // GET: Rhythm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rhythm = await _context.Rhythm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rhythm == null)
            {
                return NotFound();
            }

            return View(rhythm);
        }

        // POST: Rhythm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rhythm = await _context.Rhythm.FindAsync(id);
            _context.Rhythm.Remove(rhythm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RhythmExists(int id)
        {
            return _context.Rhythm.Any(e => e.Id == id);
        }
    }
}
