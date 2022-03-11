using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;

namespace NetAtlas.Controllers.ViewComponents
{
    public class RessourceMessageViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RessourceMessageViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var applicationDbContext = _context.RessourceMessage.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> GetMessages()
        {
            var applicationDbContext = _context.RessourceMessage.Include(r => r.Publication);
            return (IActionResult)View(await applicationDbContext.ToListAsync());
        }
    }
}
