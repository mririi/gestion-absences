using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestionabscence.Models;
using GestionAbscences.ViewModel;

namespace GestionAbscences.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly MyDbContext _context;

        public AbsencesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Absences.Include(a => a.Student).Include(a => a.Student.User).Include(a => a.Subject);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.Absences
                .Include(a => a.Student)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.AbsenceId == id);
            if (absences == null)
            {
                return NotFound();
            }

            return View(absences);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            var users = _context.Users.ToList().Where(x => x.Role == "Student");
            var subjects = _context.Subjects.ToList();
            ViewData["StudentId"] = new SelectList(users, "Id", "FullName");
            ViewData["SubjectId"] = new SelectList(subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Absences absences)
        {
         
                _context.Add(absences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.Absences.FindAsync(id);
            if (absences == null)
            {
                return NotFound();
            }
            var users = _context.Users.ToList().Where(x => x.Role == "Student");
            var subjects = _context.Subjects.ToList();
            ViewData["StudentId"] = new SelectList(users, "Id", "FullName");
            ViewData["SubjectId"] = new SelectList(subjects, "SubjectId", "SubjectName");
            return View(absences);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbsenceId,HoursNumber,Date,StudentId,SubjectId")] Absences absences)
        {
            if (id != absences.AbsenceId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(absences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsencesExists(absences.AbsenceId))
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

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absences = await _context.Absences
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.AbsenceId == id);
            if (absences == null)
            {
                return NotFound();
            }

            return View(absences);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absences = await _context.Absences.FindAsync(id);
            if (absences != null)
            {
                _context.Absences.Remove(absences);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsencesExists(int id)
        {
            return _context.Absences.Any(e => e.AbsenceId == id);
        }
    }
}
