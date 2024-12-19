using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Contacts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ContactDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<ContactDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ContactDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Contacts.OrderByDescending(u => u.CreatedDate)
                .ProjectTo<ContactDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<ContactDto>>.Success(await PagedList<ContactDto>
                .CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}