using System.Text.Json.Serialization;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Banners
{
    public class BannerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string BannerImage { get; set; }
        [JsonIgnore]
        public IFormFile FileImage { get; set; }
        public string BannerCategoryId { get; set; }
        public string PhotoId { get; set; }
        public DateTime UpdatedDate { get; set; }

        public BannerCategory BannerCategory { get; set; }
    }
}