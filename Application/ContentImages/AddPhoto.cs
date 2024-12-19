using System;
using Application.Contents;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ContentImages
{
    public class AddPhoto
    {
        public class Command : IRequest<Result<ICollection<ContentImage>>>
        {
            public ContentImageDto ContentImageDto { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<ICollection<ContentImage>>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }
            public async Task<Result<ICollection<ContentImage>>> Handle(Command request, CancellationToken cancellationToken)
            {

                var addedPhotos = new List<ContentImage>();

                foreach (IFormFile File in request.ContentImageDto.Files)
                {
                    var PhotoUploadResult = await _photoAccessor.AddPhoto(File);
                    var photo = new ContentImage
                    {
                        Url = PhotoUploadResult.Url,
                        Id = PhotoUploadResult.PublicId,
                        IsMain = false,
                        ContentId = request.ContentImageDto.ContentId == Guid.Empty ? (Guid?)null : request.ContentImageDto.ContentId,
                    };

                    _context.ContentImages.Add(photo);
                    addedPhotos.Add(photo);
                }

                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<ICollection<ContentImage>>.Success(addedPhotos);
                return Result<ICollection<ContentImage>>.Failure("Problem adding Photo");
            }
        }
    }
}