namespace Web_Application_with_Identity.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PostTag> PostTags { get; set; }

    }
}
