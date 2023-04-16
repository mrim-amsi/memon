namespace Web_Application_with_Identity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }


    }
}
