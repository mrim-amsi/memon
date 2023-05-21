using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Controllers.Api
{
        [ApiController]
        [Route("Api/[controller]")]
        public class OrderApiController : Controller
        {
            private readonly AppDBContext _context;
            private readonly IWebHostEnvironment _hostEnvironment;
        public OrderApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
            {
                _context = postDbContext;
                _hostEnvironment = webHostEnvironment;
             }
        [HttpGet]
        [Route("Orders")]
        public ActionResult GetOrder(string UserId)
        {
            List<order> order =
                _context.orders.Include(n => n.Post).Where(x=>x.UserId== UserId).ToList();

            return Ok(order);
        }
        [HttpGet]
        [Route("Favorites")]
        public ActionResult Get(string UserId)
        {
            List<Favorite> favorites =
                _context.Favorites.Include(n => n.Post).Where(x => x.UserId == UserId).ToList();

            return Ok(favorites);
        }
        [HttpPost]
        [Route("Favorites")]
        public IActionResult PostFavorite(string UserId, int postId)
        {
            Favorite post =new Favorite
            {
                UserId = UserId,
                PostId=postId,
            };
            _context.Favorites.Add(post);
            _context.SaveChanges();
             _context.SaveChanges();
               return Ok("Done");
        }


        [HttpPost]
        [Route("Orders")]
        public async Task<IActionResult> PostOrder(order post)
        {
            _context.orders.Add(post);
            _context.SaveChanges();
            _context.SaveChanges();
            return Ok("Done");
        }

    }
}
