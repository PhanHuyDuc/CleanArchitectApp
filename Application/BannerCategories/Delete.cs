using Application.Core;
using MediatR;
using Persistence;

namespace Application.BannerCategories
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var bannerCat = await _context.BannerCategories.FindAsync(request.Id);
                if (bannerCat == null) return null;
                _context.Remove(bannerCat);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to delete Banner Category");
            }
        }
    }
}