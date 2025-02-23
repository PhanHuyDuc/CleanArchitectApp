using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Widget
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string WidgetCategoryId { get; set; }
        public required WidgetCategory WidgetCategory { get; set; }
    }
}