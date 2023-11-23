using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class MonetaryAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonetaryAllocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonetaryAllocation.Include(m => m.Disaster).Include(m => m.MonetaryDonation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonetaryAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonetaryAllocation == null)
            {
                return NotFound();
            }

            var monetaryAllocation = await _context.MonetaryAllocation
                .Include(m => m.Disaster)
                .Include(m => m.MonetaryDonation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (monetaryAllocation == null)
            {
                return NotFound();
            }

            return View(monetaryAllocation);
        }

        // GET: MonetaryAllocations/Create
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId");
            ViewData["MonetaryId"] = new SelectList(_context.MonetaryDonation, "MonetaryId", "MonetaryId");
            return View();
        }

        // POST: MonetaryAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,DisasterId,MonetaryId,AllocationDate,Amount")] MonetaryAllocation monetaryAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetaryAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", monetaryAllocation.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.MonetaryDonation, "MonetaryId", "MonetaryId", monetaryAllocation.MonetaryId);
            return View(monetaryAllocation);
        }

        // GET: MonetaryAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonetaryAllocation == null)
            {
                return NotFound();
            }

            var monetaryAllocation = await _context.MonetaryAllocation.FindAsync(id);
            if (monetaryAllocation == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", monetaryAllocation.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.MonetaryDonation, "MonetaryId", "MonetaryId", monetaryAllocation.MonetaryId);
            return View(monetaryAllocation);
        }

        // POST: MonetaryAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,DisasterId,MonetaryId,AllocationDate,Amount")] MonetaryAllocation monetaryAllocation)
        {
            if (id != monetaryAllocation.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryAllocationExists(monetaryAllocation.AllocationId))
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
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", monetaryAllocation.DisasterId);
            ViewData["MonetaryId"] = new SelectList(_context.MonetaryDonation, "MonetaryId", "MonetaryId", monetaryAllocation.MonetaryId);
            return View(monetaryAllocation);
        }

        // GET: MonetaryAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonetaryAllocation == null)
            {
                return NotFound();
            }

            var monetaryAllocation = await _context.MonetaryAllocation
                .Include(m => m.Disaster)
                .Include(m => m.MonetaryDonation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (monetaryAllocation == null)
            {
                return NotFound();
            }

            return View(monetaryAllocation);
        }

        // POST: MonetaryAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonetaryAllocation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MonetaryAllocation'  is null.");
            }
            var monetaryAllocation = await _context.MonetaryAllocation.FindAsync(id);
            if (monetaryAllocation != null)
            {
                _context.MonetaryAllocation.Remove(monetaryAllocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryAllocationExists(int id)
        {
          return (_context.MonetaryAllocation?.Any(e => e.AllocationId == id)).GetValueOrDefault();
        }
    }
}
