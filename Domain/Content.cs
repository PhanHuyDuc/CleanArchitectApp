using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Content
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
        public required string ShortDes { get; set; }
        public required string ContentSource { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public bool IsSpecial { get; set; }
        public required string ContentCategoryId { get; set; }
        public ICollection<ContentImage>? ContentImages { get; set; }
        public string? Author { get; set; }
        public ContentCategory? ContentCategory { get; set; }

    }
}