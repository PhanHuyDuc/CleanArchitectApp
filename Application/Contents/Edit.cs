using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Contents
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ContentDto ContentDto { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(u => u.ContentDto).SetValidator(new ContentValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;

                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var content = await _context.Contents.FirstOrDefaultAsync(p => p.Id == request.ContentDto.Id);
                if (content == null) return null;
                _mapper.Map(request.ContentDto, content);
                _context.Entry(content).State = EntityState.Modified;
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update Content");

                if (request.ContentDto.FileImages != null && request.ContentDto.FileImages.Any())
                {
                    // Initialize the ContentImages collection if it is null
                    content.ContentImages ??= new List<ContentImage>();

                    // Iterate over each file and upload the image
                    foreach (IFormFile file in request.ContentDto.FileImages)
                    {
                        var photoUploadResult = await _photoAccessor.AddPhoto(file);
                        if (photoUploadResult == null)
                        {
                            return Result<Unit>.Failure("Failed to upload photo");
                        }

                        // Create a new ContentImage for each uploaded image
                        var photo = new ContentImage
                        {
                            Url = photoUploadResult.Url,
                            Id = photoUploadResult.PublicId,
                            ContentId = content.Id // Associate the photo with the content
                        };
                        var listImg = await _context.ContentImages.Where(p => p.ContentId == request.ContentDto.Id).ToListAsync();
                        if (!content.ContentImages.Any(x => x.IsMain) && listImg == null) photo.IsMain = true;

                        // Add the photo to the content's ContentImages collection
                        content.ContentImages.Add(photo);
                    }

                    // Update the content with the new images
                    result = await _context.SaveChangesAsync(cancellationToken) > 0;
                    if (!result) return Result<Unit>.Failure("Failed to update content with images");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}