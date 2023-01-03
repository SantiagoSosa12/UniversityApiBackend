using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackEnd.Models.DataModels;

namespace UniversityApiBackEnd.Controllers
{
    public class ChapterController : Controller
    {
        private readonly UniversityDBContext _context;

        public ChapterController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: Chapter
        public async Task<IActionResult> Index()
        {
            var universityDBContext = _context.Chapters.Include(c => c.Course);
            return View(await universityDBContext.ToListAsync());
        }

        // GET: Chapter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapters = await _context.Chapters
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chapters == null)
            {
                return NotFound();
            }

            return View(chapters);
        }

        // GET: Chapter/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "Description");
            return View();
        }

        // POST: Chapter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,ListChapters,Id,createdBy,createAt,updateddBy,updatedAt,deleteBy,deleteAt,IsDeleted")] Chapters chapters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chapters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "Description", chapters.CourseId);
            return View(chapters);
        }

        // GET: Chapter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapters = await _context.Chapters.FindAsync(id);
            if (chapters == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "Description", chapters.CourseId);
            return View(chapters);
        }

        // POST: Chapter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,ListChapters,Id,createdBy,createAt,updateddBy,updatedAt,deleteBy,deleteAt,IsDeleted")] Chapters chapters)
        {
            if (id != chapters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChaptersExists(chapters.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Set<Course>(), "Id", "Description", chapters.CourseId);
            return View(chapters);
        }

        // GET: Chapter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chapters == null)
            {
                return NotFound();
            }

            var chapters = await _context.Chapters
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chapters == null)
            {
                return NotFound();
            }

            return View(chapters);
        }

        // POST: Chapter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chapters == null)
            {
                return Problem("Entity set 'UniversityDBContext.Chapters'  is null.");
            }
            var chapters = await _context.Chapters.FindAsync(id);
            if (chapters != null)
            {
                _context.Chapters.Remove(chapters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChaptersExists(int id)
        {
          return (_context.Chapters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
