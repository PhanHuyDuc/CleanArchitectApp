using System.Text.Json.Serialization;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Contents
{
    public class ContentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDes { get; set; }
        public string ContentSource { get; set; }
        public float Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public bool IsSpecial { get; set; }
        public string ContentCategoryId { get; set; }
        [JsonIgnore]
        public ICollection<IFormFile> FileImages { get; set; }
        public List<ContentImageDto> ContentImages { get; set; }
        public string Author { get; set; }
        public string ContentCatName { get; set; }
    }
}