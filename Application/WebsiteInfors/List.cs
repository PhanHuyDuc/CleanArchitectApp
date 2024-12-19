using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.WebsiteInfors
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<WebsiteInforDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<WebsiteInforDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<WebsiteInforDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.WebsiteInfors.ProjectTo<WebsiteInforDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<WebsiteInforDto>>.Success(await PagedList<WebsiteInforDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}