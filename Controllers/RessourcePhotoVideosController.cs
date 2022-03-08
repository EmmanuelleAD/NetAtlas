#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;
using NetAtlas.Models;

namespace NetAtlas.Controllers
{
    public class RessourcePhotoVideosController : Controller
    {
        private readonly ApplicationDbContext _context;
         private UserManager<NetAtlasUser> UserManager { get; }

        public RessourcePhotoVideosController(ApplicationDbContext context, UserManager<NetAtlasUser> userManager)
        {
            _context = context;
            UserManager = userManager;  
        }

        // GET: RessourcePhotoVideos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RessourcePhotoVideo.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RessourcePhotoVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourcePhotoVideo = await _context.RessourcePhotoVideo
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourcePhotoVideo == null)
            {
                return NotFound();
            }

            return View(ressourcePhotoVideo);
        }

        // GET: RessourcePhotoVideos/Create
        public async Task<IActionResult> CreateAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            var publication = new Publication { MembreID = currentUserId, statut = "En Attente" };
            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();

            // var id = from pub in await _context.Publication.ToListAsync()
            //          select pub.ID;
            // var idMax = id.Max() ;
            ViewBag.PublicationID = publication.ID;

            //ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID");
            return View();
        }

        // POST: RessourcePhotoVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("taille,ID,NomRessource,PublicationID")] RessourcePhotoVideo ressourcePhotoVideo)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                _context.Add(ressourcePhotoVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourcePhotoVideo.PublicationID);
            return View(ressourcePhotoVideo);
        }

        // GET: RessourcePhotoVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourcePhotoVideo = await _context.RessourcePhotoVideo.FindAsync(id);
            if (ressourcePhotoVideo == null)
            {
                return NotFound();
            }
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourcePhotoVideo.PublicationID);
            return View(ressourcePhotoVideo);
        }

        // POST: RessourcePhotoVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("taille,ID,NomRessource,PublicationID")] RessourcePhotoVideo ressourcePhotoVideo)
        {
            if (id != ressourcePhotoVideo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ressourcePhotoVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RessourcePhotoVideoExists(ressourcePhotoVideo.ID))
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
            ViewData["PublicationID"] = new SelectList(_context.Publication, "ID", "MembreID", ressourcePhotoVideo.PublicationID);
            return View(ressourcePhotoVideo);
        }

        // GET: RessourcePhotoVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ressourcePhotoVideo = await _context.RessourcePhotoVideo
                .Include(r => r.Publication)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ressourcePhotoVideo == null)
            {
                return NotFound();
            }

            return View(ressourcePhotoVideo);
        }

        // POST: RessourcePhotoVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ressourcePhotoVideo = await _context.RessourcePhotoVideo.FindAsync(id);
            _context.RessourcePhotoVideo.Remove(ressourcePhotoVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RessourcePhotoVideoExists(int id)
        {
            return _context.RessourcePhotoVideo.Any(e => e.ID == id);
        }
    }
}
