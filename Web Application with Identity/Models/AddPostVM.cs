using Microsoft.AspNetCore.Mvc.Rendering;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity
{
    public class AddPostVM
    {
        //public Post Post { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; } 
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }
        public IEnumerable<SelectListItem> restaurants { get; set; }

    }
}
