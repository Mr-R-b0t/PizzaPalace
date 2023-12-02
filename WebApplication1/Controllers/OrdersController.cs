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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TimeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
            var orders = from s in _context.ModelVueOrders
                select s;
            switch (sortOrder)
            {
                case "time_desc":
                    orders = orders.OrderByDescending(s => s.order_time);
                    break;
                case "Status":
                    orders = orders.OrderBy(s => s.status);
                    break;
                case "status_desc":
                    orders = orders.OrderByDescending(s => s.status);
                    break;
                default:
                    orders = orders.OrderBy(s => s.order_time);
                    break;
            }
            return View(await orders.AsNoTracking().ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelVueOrders == null)
            {
                return NotFound();
            }

            var modelVueOrders = await _context.ModelVueOrders
                .FirstOrDefaultAsync(m => m.order_Id == id);
            if (modelVueOrders == null)
            {
                return NotFound();
            }

            return View(modelVueOrders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("order_Id,order_time,status")] ModelVueOrders modelVueOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelVueOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelVueOrders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelVueOrders == null)
            {
                return NotFound();
            }

            var modelVueOrders = await _context.ModelVueOrders.FindAsync(id);
            if (modelVueOrders == null)
            {
                return NotFound();
            }
            return View(modelVueOrders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("order_Id,order_time,status")] ModelVueOrders modelVueOrders)
        {
            if (id != modelVueOrders.order_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelVueOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelVueOrdersExists(modelVueOrders.order_Id))
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
            return View(modelVueOrders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelVueOrders == null)
            {
                return NotFound();
            }

            var modelVueOrders = await _context.ModelVueOrders
                .FirstOrDefaultAsync(m => m.order_Id == id);
            if (modelVueOrders == null)
            {
                return NotFound();
            }

            return View(modelVueOrders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelVueOrders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModelVueOrders'  is null.");
            }
            var modelVueOrders = await _context.ModelVueOrders.FindAsync(id);
            if (modelVueOrders != null)
            {
                _context.ModelVueOrders.Remove(modelVueOrders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult GetClerks()
        {
            ViewBag.clerks = _context.Clerks.ToList();
            return ViewBag.clerks;
        }

        public ActionResult GetCustomers()
        {
            ViewBag.customers = _context.Customers.ToList();
            return ViewBag.customers;
        }   

        public ActionResult GetPizzas()
        {
            ViewBag.pizzas = _context.Pizzas.ToList();
            return ViewBag.pizzas;
        }

        public ActionResult GetDrinks()
        {
            ViewBag.drinks = _context.Drinks.ToList();
            return ViewBag.drinks;
        }        private bool ModelVueOrdersExists(int id)
        {
            return (_context.ModelVueOrders?.Any(e => e.order_Id == id)).GetValueOrDefault();
        }
    }
}
