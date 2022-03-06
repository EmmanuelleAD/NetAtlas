using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;
using NetAtlas.Models;

namespace NetAtlas.Controllers
{
    public class NetAtlasUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NetAtlasUsersController(ApplicationDbContext context)
        {
            _context = context;

        }
      //  [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.NetAtlasUser.ToListAsync());
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netAtlasUser = await _context.NetAtlasUser
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (netAtlasUser == null)
            {
                return NotFound();
            }
            return View(netAtlasUser);

            
        }


        [HttpPost,ActionName("Edit")]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenoms,Statuts")] NetAtlasUser netAtlasUser)
        {
            if (!id.Equals(netAtlasUser.Id) )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(netAtlasUser);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!NetAtlasUserExists(netAtlasUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(netAtlasUser);
        }

            // GET: DemandeDAmis/Delete/5
           // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netAtlasUser = await _context.NetAtlasUser
                .FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (netAtlasUser == null)
            {
                return NotFound();
            }

            return View(netAtlasUser);
        }

        // POST: DemandeDAmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var netAtlasUser = await _context.NetAtlasUser.FindAsync(id);
           
            _context.NetAtlasUser.Remove(netAtlasUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool NetAtlasUserExists(string id)
        {
            return _context.NetAtlasUser.Any(e => e.Id.Equals(id));
        }

    }
}
