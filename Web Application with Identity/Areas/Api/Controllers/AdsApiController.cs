using Microsoft.AspNetCore.Mvc;
using Web_Application_with_Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml;
using Newtonsoft.Json;

namespace Web_Application_with_Identity.Areas.Api.Controllers
{

    public class AdsApiController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdsApiController(AppDBContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }
        public ActionResult Get()
        {
            List<Ads> Ads =
                _context.Ads.ToList();

            return Ok(Ads);
        }

    }
}
