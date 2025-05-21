namespace TechTweetAPI.Models.DTO.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
