using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ContentImages
{
    public class SetMain
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

                var contentImg = await _context.ContentImages.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (contentImg == null) return null;
                var content = await _context.Contents.Include(u => u.ContentImages).FirstOrDefaultAsync(x => x.Id == contentImg.ContentId);
                if (content == null) return null;
                var currentMain = content.ContentImages.FirstOrDefault(x => x.IsMain);
                if (currentMain != null) currentMain.IsMain = false;

                contentImg.IsMain = true;
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Prolem setting main photo content");
            }
        }
    }
}