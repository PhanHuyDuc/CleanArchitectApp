using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Banners
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public BannerDto BannerDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(u => u.BannerDto).SetValidator(new BannerValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            public Handler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var banner = _mapper.Map<Banner>(request.BannerDto);
                if (request.BannerDto.FileImage != null)
                {
                    var PhotoUploadResult = await _photoAccessor.AddPhoto(request.BannerDto.FileImage);
                    var photo = new Photo
                    {
                        Url = PhotoUploadResult.Url,
                        Id = PhotoUploadResult.PublicId,
                        IsMain = true,
                    };

                    banner.BannerImage = photo.Url;
                    banner.PhotoId = photo.Id;
                }
                banner.IsActive = true;
                _context.Banners.Add(banner);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to create the banner and upload the photo.");

            }
        }
    }
}