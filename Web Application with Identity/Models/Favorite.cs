namespace Web_Application_with_Identity.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public meal Post { get; set; }
    }
}
