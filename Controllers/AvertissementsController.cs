#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;
using NetAtlas.Models;

namespace NetAtlas.Controllers
{
    public class AvertissementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvertissementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avertissements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Avertissement.Include(a => a.NetAtlasUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Avertissements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avertissement = await _context.Avertissement
                .Include(a => a.NetAtlasUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (avertissement == null)
            {
                return NotFound();
            }

            return View(avertissement);
        }

        // GET: Avertissements/Create
        public async Task<IActionResult> Create(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var membreAAvertir = await _context.NetAtlasUser.FindAsync(id);
            if(membreAAvertir == null)
            {
                return NotFound();
            }
            ViewData["NetAtlasUserID"] = new SelectList(_context.NetAtlasUser, "Id", "Id");
            ViewBag.id = membreAAvertir.Id;

            return View();
        }

        // POST: Avertissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NetAtlasUserID")] Avertissement avertissement)
        {
            if (!ModelState.HasReachedMaxErrors)
            {

                _context.Add(avertissement);
                var user = _context.NetAtlasUser.Single(e => e.Id == avertissement.NetAtlasUserID);
                var userEntry = _context.Entry(user).Property("Warning").CurrentValue=Convert.ToInt32(_context.Entry(user).Property("Warning").CurrentValue ) +1;
                _context.Entry(user).Property("Warning").IsModified = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NetAtlasUserID"] = new SelectList(_context.NetAtlasUser, "Id", "Id", avertissement.NetAtlasUserID);
            return View(avertissement);
        }

        // GET: Avertissements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avertissement = await _context.Avertissement.FindAsync(id);
            if (avertissement == null)
            {
                return NotFound();
            }
            ViewData["NetAtlasUserID"] = new SelectList(_context.NetAtlasUser, "Id", "Id", avertissement.NetAtlasUserID);
            return View(avertissement);
        }

        // POST: Avertissements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NetAtlasUserID")] Avertissement avertissement)
        {
            if (id != avertissement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avertissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvertissementExists(avertissement.ID))
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
            ViewData["NetAtlasUserID"] = new SelectList(_context.NetAtlasUser, "Id", "Id", avertissement.NetAtlasUserID);
            return View(avertissement);
        }

        // GET: Avertissements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avertissement = await _context.Avertissement
                .Include(a => a.NetAtlasUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (avertissement == null)
            {
                return NotFound();
            }

            return View(avertissement);
        }

        // POST: Avertissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avertissement = await _context.Avertissement.FindAsync(id);
            _context.Avertissement.Remove(avertissement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvertissementExists(int id)
        {
            return _context.Avertissement.Any(e => e.ID == id);
        }
    }
}
