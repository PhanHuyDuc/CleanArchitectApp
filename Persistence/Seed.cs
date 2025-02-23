using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
           UserManager<AppUser> userManager)
        {
           
            if (!context.ContentCategories.Any())
            {
                
                var contentCategories = new List<ContentCategory>
                {
                    new ContentCategory
                    {
                        Name = "Coffee",
                        Description="Cà phê"
                    },
                    new ContentCategory
                    {
                        Name = "Sinh tố",
                        Description="Sinh tố"
                    },
                    new ContentCategory
                    {
                        Name = "Yaourt",
                        Description="Yaourt"
                    },
                };
                await context.ContentCategories.AddRangeAsync(contentCategories);
                await context.SaveChangesAsync();
                var contents = new List<Content>
                {
                    new Content
                    {
                        Name= "Cà phê đen",
                        Description="Cà phê đen",
                        ShortDes="Coffee",
                        ContentSource="HCoffee",
                        Price=18000,
                        IsActive=true,
                        IsSpecial=true,
                        ContentCategoryId = contentCategories[0].Id,
                    },
                     new Content
                    {
                        Name= "Sinh tố dâu",
                        Description="Sinh tố dâu",
                        ShortDes="Sinh tố",
                        ContentSource="HCoffee",
                        Price=32000,
                        IsActive=true,
                        IsSpecial=true,
                        ContentCategoryId = contentCategories[1].Id,
                    },
                     new Content
                    {
                        Name= "Cà phê đen",
                        Description="Cà phê đen",
                        ShortDes="HCoffee",
                        ContentSource="HCoffee",
                        Price=18000,
                        IsActive=true,
                        IsSpecial=true,
                        ContentCategoryId = contentCategories[0].Id,
                    },
                     new Content
                    {
                        Name= "Sữa chua đá",
                        Description="Sữa chua đá",
                        ShortDes="HCoffee",
                        ContentSource="HCoffee",
                        Price=22000,
                        IsActive=true,
                        IsSpecial=true,
                        ContentCategoryId = contentCategories[2].Id,
                    },
                };

                await context.Contents.AddRangeAsync(contents);
                await context.SaveChangesAsync();
            }
            if (!context.WebsiteInfors.Any())
            {
                var infor = new List<WebsiteInfor>
                {
                    new WebsiteInfor
                    {
                        WebsiteName = "WebsiteName",
                        WebsiteAddress="WebsiteAddress",
                        WebsitePhoneNumber ="WebsitePhoneNumber",
                        WebsiteEmail="WebsiteEmail",
                        Fax="",
                        WebsiteUrl="domain.com",
                        WebsiteTitle="Title",
                        WebsiteAdminTitle="Admin",
                    },

                };
                await context.WebsiteInfors.AddRangeAsync(infor);
                await context.SaveChangesAsync();
            }
        }
    }
}