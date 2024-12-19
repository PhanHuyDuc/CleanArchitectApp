using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerCategory> BannerCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentImage> ContentImages { get; set; }

        public DbSet<ContentCategory> ContentCategories { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<WebsiteInfor> WebsiteInfors { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<WidgetCategory> WidgetCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Banner>()
            .HasOne(x => x.BannerCategory)
            .WithMany(x => x.Banners)
            .HasForeignKey(x => x.BannerCategoryId)
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Content>()
                        .HasOne(x => x.ContentCategory)
                        .WithMany(x => x.Contents)
                        .HasForeignKey(x => x.ContentCategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Menu>()
            .HasOne(x => x.MenuCategory)
            .WithMany(x => x.Menus)
            .HasForeignKey(x => x.MenuCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Widget>()
                        .HasOne(x => x.WidgetCategory)
                        .WithMany(x => x.Widgets)
                        .HasForeignKey(x => x.WidgetCategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}