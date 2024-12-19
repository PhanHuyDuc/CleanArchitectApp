using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Menus
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Menu Menu { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(u => u.Menu).SetValidator(new MenuValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Menu.ParentId != null)
                {
                    var parentMenu = await _context.Menus.FirstOrDefaultAsync(m => m.Id.ToString() == request.Menu.ParentId);
                    if (parentMenu != null)
                    {
                        request.Menu.MenuParentName = parentMenu.MenuName;
                        request.Menu.TreeView = parentMenu.TreeView + 1;
                    }

                }
                else
                {
                    request.Menu.TreeView = 1;
                }
                request.Menu.IsActive = true;
                _context.Menus.Add(request.Menu);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when create Menu");
            }
        }
    }
}