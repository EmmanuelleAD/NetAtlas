#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;
using NetAtlas.Models;

namespace NetAtlas.Controllers
{ [Authorize]
    public class PublicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<NetAtlasUser> UserManager { get; }

        public PublicationsController(ApplicationDbContext context, UserManager<NetAtlasUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: Publications
        public async Task<IActionResult> Index()
        {
            var currentUser = UserManager.GetUserId(User);
            var listePub = from pub in await _context.Publication.ToListAsync()
                          // where pub.MembreID.Equals(currentUser)
                           select pub;
            var isManager = User.IsInRole("Managers");
            if (!isManager)
            {
                listePub = listePub.Where(p => p.statut == "En Attente" || p.MembreID == currentUser);

            }
            var isAdmin = User.IsInRole("Administrators");
            ViewBag.isAdmin=isAdmin;
            ViewBag.isManager = isManager;

            return View(listePub);
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .FirstOrDefaultAsync(m => m.ID == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            
                var CurrentUserId = UserManager.GetUserId(User);
            ViewBag.CurrentUserId=CurrentUserId;
            return View();
        }
        public IActionResult Choice()
        {
           
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MembreID,statut")] Publication publication)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                
                _context.Add(publication);
                await _context.SaveChangesAsync();
                ViewBag.PublicationID =publication.ID;
                return RedirectToAction("Choice");
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MembreID,statut")] Publication publication)
        {
            if (id != publication.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.ID))
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
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .FirstOrDefaultAsync(m => m.ID == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publication.FindAsync(id);
            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publication.Any(e => e.ID == id);
        }
    }
}
