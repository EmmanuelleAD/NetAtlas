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
{
    [Authorize]
    public class DemandeDAmisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<NetAtlasUser> UserManager { get;  }    

        public DemandeDAmisController(ApplicationDbContext context, UserManager<NetAtlasUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: DemandeDAmis
        //[AllowAnonymo]
        public async Task<IActionResult> Index()
        {
            var currentUser = UserManager.GetUserId(User);
            var listeAmis=from dem in
             await _context.DemandeDAmis.ToListAsync()
             where (dem.Amis2ID.Equals(currentUser)|| dem.Amis1ID.Equals(currentUser)) && dem.Statut=="Accepté"
             select dem;
            return View(listeAmis);
        }
        public async Task<IActionResult> FriendRequest()
        {
            var currentUser = UserManager.GetUserId(User);
            var friendRequest = from dem in
               await _context.DemandeDAmis.ToListAsync()
                            where dem.Amis2ID.Equals(currentUser) && dem.Statut == "En Attente"
                            select dem;
            return View(friendRequest);
        }


        // GET: DemandeDAmis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDAmis = await _context.DemandeDAmis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeDAmis == null)
            {
                return NotFound();
            }

            return View(demandeDAmis);
        }

        // GET: DemandeDAmis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemandeDAmis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Amis1ID,Amis2ID,Statut")] DemandeDAmis demandeDAmis)
        {
            if (!ModelState.HasReachedMaxErrors)
            {
                _context.Add(demandeDAmis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandeDAmis);
        }

        // GET: DemandeDAmis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDAmis = await _context.DemandeDAmis.FindAsync(id);
            if (demandeDAmis == null)
            {
                return NotFound();
            }
            return View(demandeDAmis);
        }

        // POST: DemandeDAmis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Amis1ID,Amis2ID,Statut")] DemandeDAmis demandeDAmis)
        {
            if (id != demandeDAmis.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandeDAmis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandeDAmisExists(demandeDAmis.ID))
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
            return View(demandeDAmis);
        }

        // GET: DemandeDAmis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demandeDAmis = await _context.DemandeDAmis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (demandeDAmis == null)
            {
                return NotFound();
            }

            return View(demandeDAmis);
        }

        // POST: DemandeDAmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demandeDAmis = await _context.DemandeDAmis.FindAsync(id);
            _context.DemandeDAmis.Remove(demandeDAmis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandeDAmisExists(int id)
        {
            return _context.DemandeDAmis.Any(e => e.ID == id);
        }
    }
}
