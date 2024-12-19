using System.Text.Json.Serialization;

namespace Domain
{
    public class BannerCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Banner> Banners { get; set; }
    }
}