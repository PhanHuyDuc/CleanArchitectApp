namespace Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }

    }
}