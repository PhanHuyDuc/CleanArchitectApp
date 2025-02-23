using System.Text.Json.Serialization;

namespace Domain
{
    public class ContentCategory
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        [JsonIgnore]
        public required ICollection<Content> Contents { get; set; }
    }
}