using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Menus
{
    public class ToggleIsActive
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
                var menu = await _context.Menus.FindAsync(request.Id);

                if (menu == null) return Result<Unit>.Failure("Menu not found");

                // Toggle the IsActive field
                menu.IsActive = !menu.IsActive;

                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to update IsActive status");
            }
        }
    }
}