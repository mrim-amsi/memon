using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Application_with_Identity.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriesController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Category> categories =
                _context.Categories.Include(x => x.Posts).ToList();

            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {

            AddCategoryVM addCategoryVM = new AddCategoryVM();


            return View(addCategoryVM);
        }
        [HttpPost]
        public IActionResult Add(AddCategoryVM category)
        {

            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(category.Image.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            category.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            var categoryAdded = new Category
            {
                Name = category.Name,
                ImageName = uniqueName
            };


            _context.Categories.Add(categoryAdded);

            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
    }
}
