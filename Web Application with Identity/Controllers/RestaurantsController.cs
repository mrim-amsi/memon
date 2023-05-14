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
            var uploadFolder1 = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName1 = Guid.NewGuid().ToString() + Path.GetExtension(restaurant.Logo.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);
            var filePath1 = Path.Combine(uploadFolder1, uniqueName1);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            restaurant.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            restaurant.Image.CopyTo(new FileStream(filePath1, FileMode.Create));


            var RestaurantAdded = new Restaurant
            {
                Name = restaurant.Name,
                Image = uniqueName,
                Address = restaurant.Location.Address,
                Lat = restaurant.Location.Lat,
                Lng = restaurant.Location.Lng,
                Logo = uniqueName1,

            };


            _context.Restaurants.Add(RestaurantAdded);

            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
             var restaurant = await _context.Restaurants.FindAsync(id);
             _context.Restaurants.Remove(restaurant);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));

        }
    }
}
