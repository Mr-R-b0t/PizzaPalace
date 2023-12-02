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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["NumberOfOrdersSortParm"] = sortOrder == "NumberOfOrders" ? "number_of_orders_desc" : "NumberOfOrders";
            var customers = from s in _context.ModelVueCustomers
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.name);
                    break;
                case "City":
                    customers = customers.OrderBy(s => s.city);
                    break;
                case "city_desc":
                    customers = customers.OrderByDescending(s => s.city);
                    break;
                case "NumberOfOrders":
                    customers = customers.OrderBy(s => s.number_of_orders);
                    break;
                case "number_of_orders_desc":
                    customers = customers.OrderByDescending(s => s.number_of_orders);
                    break;
                default:
                    customers = customers.OrderBy(s => s.name);
                    break;
            }
            return View(await customers.AsNoTracking().ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelVueCustomers == null)
            {
                return NotFound();
            }

            var modelVueCustomers = await _context.ModelVueCustomers
                .FirstOrDefaultAsync(m => m.costumer_Id == id);
            if (modelVueCustomers == null)
            {
                return NotFound();
            }

            return View(modelVueCustomers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("costumer_Id,name,number_of_orders,city")] ModelVueCustomers modelVueCustomers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelVueCustomers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelVueCustomers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelVueCustomers == null)
            {
                return NotFound();
            }

            var modelVueCustomers = await _context.ModelVueCustomers.FindAsync(id);
            if (modelVueCustomers == null)
            {
                return NotFound();
            }
            return View(modelVueCustomers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("costumer_Id,name,number_of_orders,city")] ModelVueCustomers modelVueCustomers)
        {
            if (id != modelVueCustomers.costumer_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelVueCustomers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelVueCustomersExists(modelVueCustomers.costumer_Id))
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
            return View(modelVueCustomers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelVueCustomers == null)
            {
                return NotFound();
            }

            var modelVueCustomers = await _context.ModelVueCustomers
                .FirstOrDefaultAsync(m => m.costumer_Id == id);
            if (modelVueCustomers == null)
            {
                return NotFound();
            }

            return View(modelVueCustomers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelVueCustomers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModelVueCustomers'  is null.");
            }
            var modelVueCustomers = await _context.ModelVueCustomers.FindAsync(id);
            if (modelVueCustomers != null)
            {
                _context.ModelVueCustomers.Remove(modelVueCustomers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelVueCustomersExists(int id)
        {
          return (_context.ModelVueCustomers?.Any(e => e.costumer_Id == id)).GetValueOrDefault();
        }
    }
}
