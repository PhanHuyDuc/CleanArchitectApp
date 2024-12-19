
namespace Domain
{
    public class ContentImage
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public Guid? ContentId { get; set; }

    }
}