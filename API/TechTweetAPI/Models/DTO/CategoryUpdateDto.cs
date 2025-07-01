namespace TechTweetAPI.Models.DTO
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
