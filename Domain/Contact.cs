namespace Domain
{
    public class Contact
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }
        public required string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}