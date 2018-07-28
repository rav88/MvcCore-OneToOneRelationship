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
    public class ConsultationsController : Controller
    {
        private readonly EfcDbContext _context;

        public ConsultationsController(EfcDbContext context)
        {
            _context = context;
        }

        // GET: ConsultationModels
        public async Task<IActionResult> Index(int id)
        {
            return View(await _context.Consultations.Where(q => q.CustomerId == id).ToListAsync());
        }

        // GET: ConsultationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationModel = await _context.Consultations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consultationModel == null)
            {
                return NotFound();
            }

            return View(consultationModel);
        }

        // GET: ConsultationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsultationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Description")] ConsultationModel consultationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultationModel);
        }

        // GET: ConsultationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationModel = await _context.Consultations.SingleOrDefaultAsync(m => m.Id == id);
            if (consultationModel == null)
            {
                return NotFound();
            }
            return View(consultationModel);
        }

        // POST: ConsultationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Description")] ConsultationModel consultationModel)
        {
            if (id != consultationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationModelExists(consultationModel.Id))
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
            return View(consultationModel);
        }

        // GET: ConsultationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationModel = await _context.Consultations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consultationModel == null)
            {
                return NotFound();
            }

            return View(consultationModel);
        }

        // POST: ConsultationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultationModel = await _context.Consultations.SingleOrDefaultAsync(m => m.Id == id);
            _context.Consultations.Remove(consultationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationModelExists(int id)
        {
            return _context.Consultations.Any(e => e.Id == id);
        }
    }
}
