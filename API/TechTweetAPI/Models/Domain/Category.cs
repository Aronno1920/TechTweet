
namespace TechTweetAPI.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; } = null;
        public DateTime? UpdatedDate { get; set; }
    }
}
