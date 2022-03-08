#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;
using NetAtlas.Models;

namespace NetAtlas.Controllers
{
    public class RessourceLiensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<NetAtlasUser> UserManager { get; }

        public RessourceLiensController(ApplicationDbContext context, UserManager<NetAtlasUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: RessourceLiens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RessourceLien.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RessourceLiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceLien = await _context.RessourceLien
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourceLien == null)
            {
                return NotFound();
            }

            return View(ressourceLien);
        }

        // GET: RessourceLiens/Create
        public async Task<IActionResult> CreateAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            var publication = new Publication {MembreID=currentUserId ,statut="En Attente"};
            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();
            
           // var id = from pub in await _context.Publication.ToListAsync()
           //          select pub.ID;
           // var idMax = id.Max() ;
            ViewBag.PublicationID= publication.ID;
            

            // ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID");
            return View();
        }

        // POST: RessourceLiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("contenuLien,ID,NomRessource,PublicationID")] RessourceLien ressourceLien)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                _context.Add(ressourceLien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceLien.PublicationID);
            return View(ressourceLien);
        }

        // GET: RessourceLiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceLien = await _context.RessourceLien.FindAsync(id);
            if (ressourceLien == null)
            {
                return NotFound();
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceLien.PublicationID);
            return View(ressourceLien);
        }

        // POST: RessourceLiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("contenuLien,ID,NomRessource,PublicationID")] RessourceLien ressourceLien)
        {
            if (id != ressourceLien.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ressourceLien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RessourceLienExists(ressourceLien.ID))
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
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourceLien.PublicationID);
            return View(ressourceLien);
        }

        // GET: RessourceLiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourceLien = await _context.RessourceLien
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourceLien == null)
            {
                return NotFound();
            }

            return View(ressourceLien);
        }

        // POST: RessourceLiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ressourceLien = await _context.RessourceLien.FindAsync(id);
            _context.RessourceLien.Remove(ressourceLien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RessourceLienExists(int id)
        {
            return _context.RessourceLien.Any(e => e.ID == id);
        }
    }
}
