using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Menus
{
    public class Edit
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
                var menu = await _context.Menus.FindAsync(request.Menu.Id);
                if (menu == null) return null;

                if (request.Menu.ParentId != "")
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

                _mapper.Map(request.Menu, menu);
                _context.Entry(menu).State = EntityState.Modified;

                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when Update Menu");
            }
        }
    }
}