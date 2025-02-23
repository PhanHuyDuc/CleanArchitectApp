namespace Domain
{
    public class WebsiteInfor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string WebsiteName { get; set; }
        public required string WebsiteAddress { get; set; }
        public required string WebsitePhoneNumber { get; set; }
        public string? WebsitePhoneNumber2 { get; set; }
        public string? WebsitePhoneNumber3 { get; set; }
        public required string WebsiteEmail { get; set; }
        public string? WebsiteEmail2 { get; set; }
        public string? WebsiteEmail3 { get; set; }
        public required string Fax { get; set; }
        public required string WebsiteUrl { get; set; }
        public required string WebsiteTitle { get; set; }
        public required string WebsiteAdminTitle { get; set; }
    }
}