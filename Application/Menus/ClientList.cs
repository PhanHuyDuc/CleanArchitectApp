using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Menus
{
    public class ClientList
    {
        public class Query : IRequest<Result<PagedList<MenuDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<MenuDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<MenuDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Menus.OrderBy(u => u.Order).Where(u => u.IsActive == true).ProjectTo<MenuDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<MenuDto>>.Success(await PagedList<MenuDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}