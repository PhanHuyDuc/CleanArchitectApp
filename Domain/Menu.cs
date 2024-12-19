namespace Domain
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string ParentId { get; set; }
        public string MenuParentName { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public int Order { get; set; }
        public int TreeView { get; set; }
        public bool IsActive { get; set; }
        public Guid MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }

    }
}