namespace TechTweetAPI.Models.DTO
{
    public class PostUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDesciption { get; set; } = String.Empty;
        public string Content { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string UrlHandle { get; set; } = String.Empty;
        public Boolean IsPublished { get; set; } = false;
    }
}
