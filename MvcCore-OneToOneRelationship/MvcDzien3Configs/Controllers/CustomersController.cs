using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDzien3Configs.EntityConfig;
using MvcDzien3Configs.Models;

namespace MvcDzien3Configs.Controllers
{
    public class CustomersController : Controller
    {
        private readonly EfcDbContext _context;

        public CustomersController(EfcDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.Include(q => q.Address).ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerModel = await _context.Customers
	            .Include(q => q.Address)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customerModel == null)
            {
                return NotFound();
            }

            return View(customerModel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerModel customerModel)
        {
	        if (ModelState.IsValid)
            {
				customerModel.DateAdded = DateTime.Now;

	            _context.Add(customerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

	        var customerModel = await _context.Customers
		        .Include(q => q.Address)
		        .SingleOrDefaultAsync(m => m.Id == id);

            if (customerModel == null)
            {
                return NotFound();
            }
            return View(customerModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerModel customerModel)
        {
            if (id != customerModel.Id)
            {
                return NotFound();
            }

	        var customerDb = await _context.Customers
		        .Include(q => q.Address)
		        .SingleOrDefaultAsync(m => m.Id == id);

	        customerDb.DateAdded = customerModel.DateAdded;
	        customerDb.DateUpdated = DateTime.Now;

	        customerDb.Age = customerModel.Age;
	        customerDb.Firstname = customerModel.Firstname;
	        customerDb.LastName = customerModel.LastName;

	        customerDb.Address.City = customerModel.Address.City;
	        customerDb.Address.Street = customerModel.Address.Street;
	        customerDb.Address.PostalCode = customerModel.Address.PostalCode;

			if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerModelExists(customerDb.Id))
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
            return View(customerModel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerModel = await _context.Customers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customerModel == null)
            {
                return NotFound();
            }

            return View(customerModel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerModel = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerModelExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
