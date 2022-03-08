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
            ViewBag.id = netAtlasUser.Id;
            return View(netAtlasUser);

            
        }


        [HttpPost,ActionName("Edit")]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Warning,Prenoms,Statuts")] NetAtlasUser netAtlasUser)
        {
            if (id!=netAtlasUser.Id )
            {
                return NotFound();
            }

            if (!ModelState.HasReachedMaxErrors)
            {
                try
                {
                    var user = _context.NetAtlasUser.Single(e => e.Id == id);
                    var userEntry = _context.Entry(user).Property("Statuts").CurrentValue =Convert.ToString( Request.Form["Statuts"]);
                    _context.Entry(user).Property("Statuts").IsModified = true;
                    //netAtlasUser.Id = id;
                    //_context.Update(netAtlasUser);
                    await  _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            /*    catch (DbUpdateConcurrencyException ex)
                {


                    // Update original values from the database 
                     var entry = ex.Entries.Single();
                     entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                   // ex.Entries.Single().Reload();
                    return RedirectToAction(nameof(Index));

                }*/
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
