using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml;
//using Newtonsoft.Json;

namespace Web_Application_with_Identity.Controllers
{

    public class RestaurantsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RestaurantsController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        
        public ActionResult Index()
        {
            List<Restaurant> Restaurant =
                _context.Restaurants.ToList();

            return View(Restaurant);
        }

        [HttpGet]
        public IActionResult Add()
        {

            RestaurantVM addRestaurantVM = new RestaurantVM();


            return View(addRestaurantVM);
        }
        [HttpPost]
        public IActionResult Add(RestaurantVM restaurant)
        {

            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(restaurant.Image.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            restaurant.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            var RestaurantAdded = new Restaurant
            {
                Name = restaurant.Name,
                Image = uniqueName
            };


            _context.Restaurants.Add(RestaurantAdded);

            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
    }
}
