namespace Domain
{
    public class Banner
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public Guid BannerCategoryId { get; set; }
        public required string PhotoId { get; set; }
        public required string BannerImage { get; set; }
        public required BannerCategory BannerCategory { get; set; }

    }
}