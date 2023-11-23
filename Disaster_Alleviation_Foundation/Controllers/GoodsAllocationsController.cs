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
    public class GoodsAllocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsAllocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsAllocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoodsAllocation.Include(g => g.Disaster).Include(g => g.GoodsDonation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GoodsAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .Include(g => g.Disaster)
                .Include(g => g.GoodsDonation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Create
        public IActionResult Create()
        {
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId");
            ViewData["GoodsId"] = new SelectList(_context.GoodsDonation, "GoodsId", "GoodsId");
            return View();
        }

        // POST: GoodsAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,DisasterId,GoodsId,AllocationDate,ItemCount")] GoodsAllocation goodsAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", goodsAllocation.DisasterId);
            ViewData["GoodsId"] = new SelectList(_context.GoodsDonation, "GoodsId", "GoodsId", goodsAllocation.GoodsId);
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", goodsAllocation.DisasterId);
            ViewData["GoodsId"] = new SelectList(_context.GoodsDonation, "GoodsId", "GoodsId", goodsAllocation.GoodsId);
            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,DisasterId,GoodsId,AllocationDate,ItemCount")] GoodsAllocation goodsAllocation)
        {
            if (id != goodsAllocation.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsAllocationExists(goodsAllocation.AllocationId))
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
            ViewData["DisasterId"] = new SelectList(_context.Disaster, "DisasterId", "DisasterId", goodsAllocation.DisasterId);
            ViewData["GoodsId"] = new SelectList(_context.GoodsDonation, "GoodsId", "GoodsId", goodsAllocation.GoodsId);
            return View(goodsAllocation);
        }

        // GET: GoodsAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsAllocation == null)
            {
                return NotFound();
            }

            var goodsAllocation = await _context.GoodsAllocation
                .Include(g => g.Disaster)
                .Include(g => g.GoodsDonation)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (goodsAllocation == null)
            {
                return NotFound();
            }

            return View(goodsAllocation);
        }

        // POST: GoodsAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsAllocation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoodsAllocation'  is null.");
            }
            var goodsAllocation = await _context.GoodsAllocation.FindAsync(id);
            if (goodsAllocation != null)
            {
                _context.GoodsAllocation.Remove(goodsAllocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsAllocationExists(int id)
        {
          return (_context.GoodsAllocation?.Any(e => e.AllocationId == id)).GetValueOrDefault();
        }
    }
}
