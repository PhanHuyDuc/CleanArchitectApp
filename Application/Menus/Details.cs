using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Menus
{
    public class Details
    {
        public class Query : IRequest<Result<MenuDto>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<MenuDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<MenuDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var menu = await _context.Menus.ProjectTo<MenuDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<MenuDto>.Success(menu);
            }
        }
    }
}