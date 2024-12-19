using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Banners
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var banner = await _context.Banners.FindAsync(request.Id);
                if (banner == null) return null;
                if (banner.PhotoId != null)
                {
                    await _photoAccessor.DeletePhoto(banner.PhotoId);
                }
                _context.Remove(banner);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to delete banner");
            }
        }
    }
}