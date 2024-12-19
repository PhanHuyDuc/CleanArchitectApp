using Application.Core;
using MediatR;
using Persistence;

namespace Application.Contents
{
    public class ToggleIsActive
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var content = await _context.Contents.FindAsync(request.Id);

                if (content == null) return Result<Unit>.Failure("content not found");

                // Toggle the IsActive field
                content.IsActive = !content.IsActive;

                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to update IsActive status");
            }
        }
    }
}