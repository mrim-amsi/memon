using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.Include(x => x.Category)
                .Include(x => x.PostTags)
                .ThenInclude(x=>x.Tag)
                .ToList();

            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> posts()
        {
            List<Post> posts = _context.Posts.ToList();

            return Ok(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = _context.Categories.ToList();

            AddPostVM addPostVM = new AddPostVM();
            addPostVM.categories = new SelectList(categories, "Id", "Name");


            return View(addPostVM);
        }
        [HttpPost]
        public IActionResult Add(AddPostVM post)
        {

            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(post.Image.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            post.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            var postAdded = new Post
            {
                Title = post.Title,
                Body = post.Body,
                CategoryId = post.CategoryId,
                ImageName = uniqueName
            };


            _context.Posts.Add(postAdded);

            _context.SaveChanges();

            _context.PostTags.Add(new PostTag { PostId = postAdded.Id, TagId = 1 });
            _context.PostTags.Add(new PostTag { PostId = postAdded.Id, TagId = 2 });

            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
    }
}
