using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Disasters = await _context.Disaster.ToListAsync(),
                MonetaryDonations = await _context.MonetaryDonation.ToListAsync(),
                GoodsDonations = await _context.GoodsDonation.ToListAsync(),
                MonetaryAllocation = await _context.MonetaryAllocation.ToListAsync(),
                GoodsAllocation = await _context.GoodsAllocation.ToListAsync(),

                // Calculate totals
                TotalMoneyDonated = await _context.MonetaryDonation.SumAsync(m => m.Amount),
                TotalGoodsDonated = await _context.GoodsDonation.SumAsync(g => g.ItemCount),
                AvailableMoney = await _context.MonetaryDonation.SumAsync(m => m.Amount) - await _context.MonetaryAllocation.SumAsync(m => m.Amount),
                AvailableGoods = await _context.GoodsDonation.SumAsync(g => g.ItemCount) - await _context.GoodsAllocation.SumAsync(g => g.ItemCount)
            };


            return View(viewModel); // Pass the viewModel to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}