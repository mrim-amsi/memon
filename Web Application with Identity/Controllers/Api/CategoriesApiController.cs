using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Application_with_Identity.Api.Controllers
{

    public class CategoriesApiController : Controller
    {
        private readonly AppDBContext _context;

        public CategoriesApiController(AppDBContext postDbContext)
        {
            _context = postDbContext;
        }

        public IActionResult Get()
        {
            List<Category> categories =
                _context.Categories.Include(x => x.Posts).ToList();

            return Ok(categories);
        }
    }
}
