using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Areas.Api.Controllers
{

    public class MealsApiController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MealsApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Get()
        {
            List<meal> posts = _context.Meals
                .ToList();

            return Ok(posts);
        }


        public IActionResult Post(AddPostVM post)
        {

            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(post.Image.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            post.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            var postAdded = new meal
            {
                Title = post.Title,
                Body = post.Body,
                CategoryId = post.CategoryId,
                ImageName = uniqueName
            };


            _context.Meals.Add(postAdded);

            _context.SaveChanges();


            _context.SaveChanges();

            return Ok("Done");
        }
    }
}
