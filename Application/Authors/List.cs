using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Authors
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<AuthorDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<AuthorDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<AuthorDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Authors.OrderBy(u => u.Name).ProjectTo<AuthorDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<AuthorDto>>.Success(await PagedList<AuthorDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}