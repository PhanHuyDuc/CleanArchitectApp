namespace Application.Contacts
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}