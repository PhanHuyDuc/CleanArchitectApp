using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Application.Contents
{
    public class ContentImageDto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        [JsonIgnore]
        public ICollection<IFormFile> Files { get; set; }
        public required string ContentId { get; set; }
    }
}