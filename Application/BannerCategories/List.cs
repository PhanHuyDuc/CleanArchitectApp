using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.BannerCategories
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<BannerCatDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<BannerCatDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<BannerCatDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.BannerCategories.OrderBy(u => u.Name).ProjectTo<BannerCatDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<BannerCatDto>>.Success(await PagedList<BannerCatDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}