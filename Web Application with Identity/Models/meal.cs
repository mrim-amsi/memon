

using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Application_with_Identity.Models
{
    public class meal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? ImageName { get; set; }
        public Double Price { get; set; } 
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }



    }
}
