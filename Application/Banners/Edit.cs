using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Banners
{
    public class Edit
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
                // Check if banner exists by Id

                var banner = await _context.Banners.FirstOrDefaultAsync(u => u.Id == request.BannerDto.Id);
                if (banner == null) return null;
                _mapper.Map(request.BannerDto, banner);
                //check new file image is provided
                if (request.BannerDto.FileImage != null)
                {
                    var resultImage = await UpdateBannerPhoto(banner, request.BannerDto.FileImage);
                    if (!resultImage) return Result<Unit>.Failure("Failed to update banner");
                }
                // Save the changes to the database
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when Update Banner");
            }
            private async Task<bool> UpdateBannerPhoto(Banner banner, IFormFile newFileImage)
            {
                // Upload new photo
                var photoUploadResult = await _photoAccessor.AddPhoto(newFileImage);
                if (photoUploadResult == null) return false;

                // Delete old photo if exists
                if (banner.PhotoId != null)
                {
                    var deletionResult = await _photoAccessor.DeletePhoto(banner.PhotoId);
                    if (deletionResult == null) return false;
                }

                // Update banner with new photo details
                banner.BannerImage = photoUploadResult.Url;
                banner.PhotoId = photoUploadResult.PublicId;

                return true;
            }
        }
    }
}