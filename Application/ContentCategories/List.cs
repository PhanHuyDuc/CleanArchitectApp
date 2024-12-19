using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.ContentCategories
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ContentCatDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<ContentCatDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ContentCatDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.ContentCategories.OrderBy(u => u.Name).ProjectTo<ContentCatDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<ContentCatDto>>.Success(await PagedList<ContentCatDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}