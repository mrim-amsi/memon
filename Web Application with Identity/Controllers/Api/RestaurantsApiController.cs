using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml;
//using Newtonsoft.Json;

namespace Web_Application_with_Identity.Controllers.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class RestaurantsApiController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RestaurantsApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("Get")]
        public ActionResult Get()
        {
            List<Restaurant> Restaurant =
                _context.Restaurants.ToList();

            return Ok(Restaurant);
        }

    }
}
