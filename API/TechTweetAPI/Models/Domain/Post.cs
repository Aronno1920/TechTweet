namespace TechTweetAPI.Models.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDesciption { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public Boolean IsPublished { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
    }
}
