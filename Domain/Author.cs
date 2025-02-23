namespace Domain
{
    public class Author
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }

        public ICollection<Photo>? Photos { get; set; }

    }
}