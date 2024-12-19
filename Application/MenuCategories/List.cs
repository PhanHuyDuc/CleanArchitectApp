using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.MenuCategories
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<MenuCategoryDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<MenuCategoryDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<MenuCategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.MenuCategories.OrderBy(u => u.Name).ProjectTo<MenuCategoryDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<MenuCategoryDto>>.Success(await PagedList<MenuCategoryDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}