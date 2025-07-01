namespace TechTweetAPI.Models.DTO
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
