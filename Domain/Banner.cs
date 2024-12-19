namespace Domain
{
    public class Banner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public Guid BannerCategoryId { get; set; }
        public string PhotoId { get; set; }
        public string BannerImage { get; set; }
        public BannerCategory BannerCategory { get; set; }

    }
}