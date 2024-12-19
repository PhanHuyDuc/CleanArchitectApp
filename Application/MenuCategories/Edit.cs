using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.MenuCategories
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MenuCategory MenuCategory { get; set; }
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
                var menuCat = await _context.MenuCategories.FindAsync(request.MenuCategory.Id);
                if (menuCat == null) return null;
                _mapper.Map(request.MenuCategory, menuCat);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when Update Menu Category");
            }
        }
    }
}