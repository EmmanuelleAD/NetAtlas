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
    public class RessourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RessourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ressources
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ressource.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ressources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressource = await _context.Ressource
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressource == null)
            {
                return NotFound();
            }

            return View(ressource);
        }

        // GET: Ressources/Create
        public IActionResult Create()
        {
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID");
            return View();
        }

        // POST: Ressources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomRessource,PublicationID")] Ressource ressource)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                _context.Add(ressource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressource.PublicationID);
            return View(ressource);
        }

        // GET: Ressources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressource = await _context.Ressource.FindAsync(id);
            if (ressource == null)
            {
                return NotFound();
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressource.PublicationID);
            return View(ressource);
        }

        // POST: Ressources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomRessource,PublicationID")] Ressource ressource)
        {
            if (id != ressource.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ressource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RessourceExists(ressource.ID))
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
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressource.PublicationID);
            return View(ressource);
        }

        // GET: Ressources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressource = await _context.Ressource
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressource == null)
            {
                return NotFound();
            }

            return View(ressource);
        }

        // POST: Ressources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ressource = await _context.Ressource.FindAsync(id);
            _context.Ressource.Remove(ressource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RessourceExists(int id)
        {
            return _context.Ressource.Any(e => e.ID == id);
        }
    }
}
