using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;

namespace NetAtlas.Controllers.ViewComponents
{
    public class RessourceLienViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RessourceLienViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var applicationDbContext = _context.RessourceLien.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
