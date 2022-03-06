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
    public class RessourceMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RessourceMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RessourceMessages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RessourceMessage.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RessourceMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceMessage = await _context.RessourceMessage
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourceMessage == null)
            {
                return NotFound();
            }

            return View(ressourceMessage);
        }

        // GET: RessourceMessages/Create
        public IActionResult Create()
        {
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID");
            return View();
        }

        // POST: RessourceMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Contenu,ID,NomRessource,PublicationID")] RessourceMessage ressourceMessage)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                _context.Add(ressourceMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceMessage.PublicationID);
            return View(ressourceMessage);
        }

        // GET: RessourceMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceMessage = await _context.RessourceMessage.FindAsync(id);
            if (ressourceMessage == null)
            {
                return NotFound();
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceMessage.PublicationID);
            return View(ressourceMessage);
        }

        // POST: RessourceMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Contenu,ID,NomRessource,PublicationID")] RessourceMessage ressourceMessage)
        {
            if (id != ressourceMessage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ressourceMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RessourceMessageExists(ressourceMessage.ID))
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
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceMessage.PublicationID);
            return View(ressourceMessage);
        }

        // GET: RessourceMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceMessage = await _context.RessourceMessage
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourceMessage == null)
            {
                return NotFound();
            }

            return View(ressourceMessage);
        }

        // POST: RessourceMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ressourceMessage = await _context.RessourceMessage.FindAsync(id);
            _context.RessourceMessage.Remove(ressourceMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RessourceMessageExists(int id)
        {
            return _context.RessourceMessage.Any(e => e.ID == id);
        }
    }
}
