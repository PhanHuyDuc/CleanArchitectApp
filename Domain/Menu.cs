namespace Domain
{
    public class Menu
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public required string ParentId { get; set; }
        public required string MenuParentName { get; set; }
        public required string MenuName { get; set; }
        public required string MenuLink { get; set; }
        public int Order { get; set; }
        public int TreeView { get; set; }
        public bool IsActive { get; set; }
        public required string MenuCategoryId { get; set; }
        public required MenuCategory MenuCategory { get; set; }

    }
}