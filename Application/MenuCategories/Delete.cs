using Application.Core;
using MediatR;
using Persistence;

namespace Application.MenuCategories
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
                var menuCat = await _context.MenuCategories.FindAsync(request.Id);
                if (menuCat == null) return null;
                _context.Remove(menuCat);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to delete Menu Category");
            }
        }
    }
}