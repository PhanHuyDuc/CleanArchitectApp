using Domain;

namespace Application.Authors
{
    public class AuthorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}