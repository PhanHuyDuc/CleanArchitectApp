using System.Text.Json.Serialization;

namespace Domain
{
    public class BannerCategory
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        [JsonIgnore]
        public required ICollection<Banner> Banners { get; set; }
    }
}