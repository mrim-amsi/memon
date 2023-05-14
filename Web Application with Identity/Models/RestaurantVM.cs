namespace Web_Application_with_Identity.Models
{
    public class RestaurantVM
    {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile Image { get; set; }
        public Location Location { get; set; }
    }
}
