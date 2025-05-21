namespace TechTweetAPI.Models.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDesciption { get; set; } = String.Empty;
        public string Content { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string UrlHandle { get; set; } = String.Empty;
        public Boolean IsPublished { get; set; } = false;

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; } = null;
        public DateTime? UpdatedDate { get; set; }
    }
}
