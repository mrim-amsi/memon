using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Application_with_Identity.Api.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _context;

        public CategoriesController(AppDBContext postDbContext)
        {
            _context = postDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories =
                _context.Categories.Include(x => x.Posts).ToList();

            return Ok(categories);
        }
    }
}
