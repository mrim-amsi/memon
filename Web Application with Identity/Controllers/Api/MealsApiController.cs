using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity.Controllers.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class MealsApiController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MealsApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        //[HttpPut]
        //public async Task<IActionResult> Put()
        //{
        //    var userExsit = await _context.Meals.SingleOrDefaultAsync(x => x.Id == 10);
        //    var userExsit1 = await _context.Meals.SingleOrDefaultAsync(x => x.Id == 11);
        //    var userExsit2 = await _context.Meals.SingleOrDefaultAsync(x => x.Id == 8);
        //    userExsit.Body = "ساندوتش برجر لحم كلاسيك . قطعة برجر لحم، كابوتشا، شريحة طماطم، بصل، شريحة جبنة شيدر، خيار مخلل و مايونيز، يقدم في خبز كيزر";
        //    userExsit1.Body = "ساندوتش برجر لحم كلاسيك . قطعة برجر لحم، كابوتشا، شريحة طماطم، بصل، شريحة جبنة شيدر، خيار مخلل و مايونيز، يقدم في خبز كيزر";
        //    userExsit2.Body = "ساندوتش برجر لحم كلاسيك . قطعة برجر لحم، كابوتشا، شريحة طماطم، بصل، شريحة جبنة شيدر، خيار مخلل و مايونيز، يقدم في خبز كيزر";
        //    _context.Meals.Update(userExsit);
        //    _context.Meals.Update(userExsit1);
        //    _context.Meals.Update(userExsit2);
        //    await _context.SaveChangesAsync();
        //    return Ok(userExsit);
        //}
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            List<meal> posts = _context.Meals
                .ToList();

            return Ok(posts);
        }

        [HttpPost]
        [Route("Post")]
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
