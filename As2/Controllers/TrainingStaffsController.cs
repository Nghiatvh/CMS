using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using As2.Data;
using As2.Models;

namespace As2.Controllers
{
    public class TrainingStaffsController : Controller
    {
        private readonly CMSContext _context;

        public TrainingStaffsController(CMSContext context)
        {
            _context = context;
        }

        // GET: TrainingStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingStaffs.ToListAsync());
        }

        // GET: TrainingStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingStaff = await _context.TrainingStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingStaff == null)
            {
                return NotFound();
            }

            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Location,Id,Username,Password")] TrainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingStaff = await _context.TrainingStaffs.FindAsync(id);
            if (trainingStaff == null)
            {
                return NotFound();
            }
            return View(trainingStaff);
        }

        // POST: TrainingStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,Location,Id,Username,Password")] TrainingStaff trainingStaff)
        {
            if (id != trainingStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingStaffExists(trainingStaff.Id))
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
            return View(trainingStaff);
        }

        // GET: TrainingStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingStaff = await _context.TrainingStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingStaff == null)
            {
                return NotFound();
            }

            return View(trainingStaff);
        }

        // POST: TrainingStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingStaff = await _context.TrainingStaffs.FindAsync(id);
            _context.TrainingStaffs.Remove(trainingStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingStaffExists(int id)
        {
            return _context.TrainingStaffs.Any(e => e.Id == id);
        }
    }
}
