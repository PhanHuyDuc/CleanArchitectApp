using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Contents
{
    public class ClientList
    {
        public class Query : IRequest<Result<PagedList<ContentDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<ContentDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ContentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Contents.OrderBy(u => u.Name).Where(u => u.IsActive).ProjectTo<ContentDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<ContentDto>>.Success(await PagedList<ContentDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}