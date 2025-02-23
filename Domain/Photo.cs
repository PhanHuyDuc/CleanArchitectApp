namespace Domain
{
    public class Photo
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public required string Url { get; set; }
        public bool IsMain { get; set; }
    }
}