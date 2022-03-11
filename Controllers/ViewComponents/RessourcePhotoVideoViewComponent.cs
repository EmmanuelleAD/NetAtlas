using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Data;

namespace NetAtlas.Controllers.ViewComponents
{
    public class RessourcePhotoVideoViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RessourcePhotoVideoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var applicationDbContext = _context.RessourcePhotoVideo.Include(r => r.Publication);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
