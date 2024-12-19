using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Content
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string ShortDes { get; set; }
        public string ContentSource { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public bool IsSpecial { get; set; }
        public Guid ContentCategoryId { get; set; }
        public ICollection<ContentImage> ContentImages { get; set; }
        public string Author { get; set; }
        public ContentCategory ContentCategory { get; set; }

    }
}