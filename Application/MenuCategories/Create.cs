using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.MenuCategories
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MenuCategory MenuCategory { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.MenuCategories.Add(request.MenuCategory);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when create Menu Category");
            }
        }
    }
}