namespace Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}