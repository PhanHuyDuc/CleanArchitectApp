using Domain;

namespace Application.Menus
{
    public class MenuDto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string MenuParentName { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public int Order { get; set; }
        public int TreeView { get; set; }
        public bool IsActive { get; set; }
        public string MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }

    }
}