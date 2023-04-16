using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Application_with_Identity.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _context;

        public CategoriesController(AppDBContext postDbContext)
        {
            _context = postDbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories =
                _context.Categories.Include(x => x.Posts).ToList();

            return View(categories);
        }
    }
}
