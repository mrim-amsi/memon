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
    public class CategoriesApiController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriesApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("Get")]
        public ActionResult Get()
        {
            List<Category> categories =
                _context.Categories.ToList();

            return Ok(categories);
        }
        [HttpPost]
        [Route("Post")]
        public IActionResult Post(AddCategoryVM category)
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



            return Ok("Done");
        }
        //public IActionResult Addd(AddCategoryVM category)
        //{

        //    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
        //    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(category.Image.FileName);
        //    // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

        //    var filePath = Path.Combine(uploadFolder, uniqueName);

        //    //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
        //    category.Image.CopyTo(new FileStream(filePath, FileMode.Create));


        //    var categoryAdded = new Category
        //    {
        //        Name = category.Name,
        //        ImageName = uniqueName
        //    };


        //    _context.Categories.Add(categoryAdded);

        //    _context.SaveChanges();

        //    TempData["success"] = "Successfully Added";
        //    return Ok("Done");
        //}


    }
}