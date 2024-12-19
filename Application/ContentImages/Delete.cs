using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ContentImages
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPhotoAccessor _photoAccessor;
            private readonly DataContext _context;
            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var contentImg = await _context.ContentImages.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (contentImg == null) return null;

                if (contentImg.IsMain) return Result<Unit>.Failure("You cannot delete your main photo");
                var result = await _photoAccessor.DeletePhoto(contentImg.Id);
                if (result == null) return Result<Unit>.Failure("Problem deleting image from Cloudinary");
                _context.ContentImages.Remove(contentImg);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Problem deleting image from API");
            }
        }
    }
}