namespace TechTweetAPI.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
    }
}
