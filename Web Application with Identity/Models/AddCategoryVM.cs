using Microsoft.AspNetCore.Mvc.Rendering;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity
{
    public class AddCategoryVM
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }

    }
}
