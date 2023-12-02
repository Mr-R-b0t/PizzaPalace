using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClerksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClerksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clerks
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["NumberOfOrdersSortParm"] = sortOrder == "NumberOfOrders" ? "number_of_orders_desc" : "NumberOfOrders";
            var clerks = from s in _context.ModelVueClerks
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    clerks = clerks.OrderByDescending(s => s.name);
                    break;
                case "City":
                    clerks = clerks.OrderBy(s => s.city);
                    break;
                case "city_desc":
                    clerks = clerks.OrderByDescending(s => s.city);
                    break;
                case "NumberOfOrders":
                    clerks = clerks.OrderBy(s => s.number_of_orders);
                    break;
                case "number_of_orders_desc":
                    clerks = clerks.OrderByDescending(s => s.number_of_orders);
                    break;
                default:
                    clerks = clerks.OrderBy(s => s.name);
                    break;
            }
            return View(await clerks.AsNoTracking().ToListAsync());
        }

        // GET: Clerks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelVueClerks == null)
            {
                return NotFound();
            }

            var modelVueClerks = await _context.ModelVueClerks
                .FirstOrDefaultAsync(m => m.clerk_Id == id);
            if (modelVueClerks == null)
            {
                return NotFound();
            }

            return View(modelVueClerks);
        }

        // GET: Clerks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clerks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("clerk_Id,name,number_of_orders,city")] ModelVueClerks modelVueClerks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelVueClerks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelVueClerks);
        }

        // GET: Clerks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelVueClerks == null)
            {
                return NotFound();
            }

            var modelVueClerks = await _context.ModelVueClerks.FindAsync(id);
            if (modelVueClerks == null)
            {
                return NotFound();
            }
            return View(modelVueClerks);
        }

        // POST: Clerks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clerk_Id,name,number_of_orders,city")] ModelVueClerks modelVueClerks)
        {
            if (id != modelVueClerks.clerk_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelVueClerks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelVueClerksExists(modelVueClerks.clerk_Id))
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
            return View(modelVueClerks);
        }

        // GET: Clerks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelVueClerks == null)
            {
                return NotFound();
            }

            var modelVueClerks = await _context.ModelVueClerks
                .FirstOrDefaultAsync(m => m.clerk_Id == id);
            if (modelVueClerks == null)
            {
                return NotFound();
            }

            return View(modelVueClerks);
        }

        // POST: Clerks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelVueClerks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModelVueClerks'  is null.");
            }
            var modelVueClerks = await _context.ModelVueClerks.FindAsync(id);
            if (modelVueClerks != null)
            {
                _context.ModelVueClerks.Remove(modelVueClerks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelVueClerksExists(int id)
        {
          return (_context.ModelVueClerks?.Any(e => e.clerk_Id == id)).GetValueOrDefault();
        }
    }
}
