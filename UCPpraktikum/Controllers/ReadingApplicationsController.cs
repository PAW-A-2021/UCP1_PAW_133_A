using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCPpraktikum.Models;

namespace UCPpraktikum.Controllers
{
    public class ReadingApplicationsController : Controller
    {
        private readonly UCPpraktikumContext _context;

        public ReadingApplicationsController(UCPpraktikumContext context)
        {
            _context = context;
        }

        // GET: ReadingApplications
        public async Task<IActionResult> Index()
        {
            var uCPpraktikumContext = _context.ReadingApplication.Include(r => r.IdBookNavigation);
            return View(await uCPpraktikumContext.ToListAsync());
        }

        // GET: ReadingApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readingApplication = await _context.ReadingApplication
                .Include(r => r.IdBookNavigation)
                .FirstOrDefaultAsync(m => m.IdBook == id);
            if (readingApplication == null)
            {
                return NotFound();
            }

            return View(readingApplication);
        }

        // GET: ReadingApplications/Create
        public IActionResult Create()
        {
            ViewData["IdBook"] = new SelectList(_context.Account, "IdApplication", "IdApplication");
            return View();
        }

        // POST: ReadingApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBook,AdventureGenre,ActionGenre,FantasyGenre")] ReadingApplication readingApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(readingApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBook"] = new SelectList(_context.Account, "IdApplication", "IdApplication", readingApplication.IdBook);
            return View(readingApplication);
        }

        // GET: ReadingApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readingApplication = await _context.ReadingApplication.FindAsync(id);
            if (readingApplication == null)
            {
                return NotFound();
            }
            ViewData["IdBook"] = new SelectList(_context.Account, "IdApplication", "IdApplication", readingApplication.IdBook);
            return View(readingApplication);
        }

        // POST: ReadingApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBook,AdventureGenre,ActionGenre,FantasyGenre")] ReadingApplication readingApplication)
        {
            if (id != readingApplication.IdBook)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(readingApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReadingApplicationExists(readingApplication.IdBook))
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
            ViewData["IdBook"] = new SelectList(_context.Account, "IdApplication", "IdApplication", readingApplication.IdBook);
            return View(readingApplication);
        }

        // GET: ReadingApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readingApplication = await _context.ReadingApplication
                .Include(r => r.IdBookNavigation)
                .FirstOrDefaultAsync(m => m.IdBook == id);
            if (readingApplication == null)
            {
                return NotFound();
            }

            return View(readingApplication);
        }

        // POST: ReadingApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var readingApplication = await _context.ReadingApplication.FindAsync(id);
            _context.ReadingApplication.Remove(readingApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReadingApplicationExists(int id)
        {
            return _context.ReadingApplication.Any(e => e.IdBook == id);
        }
    }
}
