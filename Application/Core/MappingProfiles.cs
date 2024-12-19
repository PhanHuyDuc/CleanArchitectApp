
using Application.Authors;
using Application.BannerCategories;
using Application.Banners;
using Application.Contacts;
using Application.ContentCategories;
using Application.Contents;
using Application.MenuCategories;
using Application.Menus;
using Application.WebsiteInfors;
using Domain;
using Newtonsoft.Json;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            // string currentUsername = null;
            CreateMap<Author, Author>();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Contact, Contact>();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<WebsiteInfor, WebsiteInfor>();
            CreateMap<WebsiteInfor, WebsiteInforDto>().ReverseMap();
            CreateMap<MenuCategory, MenuCategory>();
            CreateMap<MenuCategory, MenuCategoryDto>().ReverseMap();
            CreateMap<Menu, Menu>();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<BannerCategory, BannerCategory>();
            CreateMap<BannerCategory, BannerCatDto>().ReverseMap();
            CreateMap<Banner, Banner>();
            CreateMap<Banner, BannerDto>().ReverseMap();
            CreateMap<ContentCategory, ContentCategory>();
            CreateMap<ContentCategory, ContentCatDto>().ReverseMap();
            CreateMap<Content, ContentImageDto>();
            CreateMap<ContentCategory, ContentDto>();
            CreateMap<Content, ContentDto>()
            .ForMember(d => d.ContentImages, o => o.MapFrom(s => s.ContentImages.Select(x => new ContentImageDto
            {
                Id = x.Id,
                Url = x.Url,
                IsMain = x.IsMain,
                ContentId = x.ContentId,
            })))
            .ForMember(d => d.ContentCatName, o => o.MapFrom(s => s.ContentCategory.Name));
            // Reverse mapping for ContentDto -> Content
            CreateMap<ContentDto, Content>()
                .ForMember(d => d.ContentImages, o => o.MapFrom(s => s.ContentImages.Select(x => new ContentImage
                {
                    Id = x.Id,
                    Url = x.Url,
                    IsMain = x.IsMain,
                    ContentId = x.ContentId,
                })))
                .ForMember(d => d.ContentCategory, o => o.Ignore()); // Handle ContentCategory separately
            CreateMap<ContentImage, ContentImageDto>().ReverseMap();
        }
    }
}