namespace Web_Application_with_Identity.Models
{
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

    }
}
