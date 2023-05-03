//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Web_Application_with_Identity.Models;

//namespace Web_Application_with_Identity.Controllers
//{
//    public class PostController : Controller
//    {
//        private readonly AppDBContext _context;
//        private readonly IWebHostEnvironment _hostEnvironment;

//        public PostController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = postDbContext;
//            _hostEnvironment = webHostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            List<meal> posts = _context.Meals
//                .ToList();

//            return View(posts);
//        }

//        [HttpGet]
//        public async Task<IActionResult> posts()
//        {
//            List<meal> posts = _context.Meals.ToList();

//            return Ok(posts);
//        }

//        [HttpGet]
//        public IActionResult Add()
//        {
//            List<Category> categories = _context.Categories.ToList();
//            List<Restaurant> restaurants = _context.Restaurants.ToList();

//            AddPostVM addPostVM = new AddPostVM();
//            addPostVM.categories = new SelectList(categories, "Id", "Name");
//            addPostVM.restaurants = new SelectList(restaurants, "Id", "Name");


//            return View(addPostVM);
//        }
//        [HttpPost]
//        public IActionResult Add(AddPostVM post)
//        {

//            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
//            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(post.Image.FileName);
//            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

//            var filePath = Path.Combine(uploadFolder, uniqueName);

//            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
//            post.Image.CopyTo(new FileStream(filePath, FileMode.Create));


//            var postAdded = new meal
//            {
//                Title = post.Title,
//                Body = post.Body,
//                CategoryId = post.CategoryId,
//                ImageName = uniqueName
//            };


//            _context.Meals.Add(postAdded);

//            _context.SaveChanges();


//            _context.SaveChanges();

//            TempData["success"] = "Successfully Added";
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
