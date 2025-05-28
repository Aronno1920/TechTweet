namespace TechTweetAPI.Models.DTO.Category
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
