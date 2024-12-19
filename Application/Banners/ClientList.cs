using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Banners
{
    public class ClientList
    {
        public class Query : IRequest<Result<PagedList<BannerDto>>>
        {
            public PagingParams Params { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<BannerDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<BannerDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Banners.OrderBy(u => u.Order).Where(u => u.IsActive).ProjectTo<BannerDto>(_mapper.ConfigurationProvider).AsQueryable();
                return Result<PagedList<BannerDto>>.Success(await PagedList<BannerDto>.CreateAsync(query, request.Params.pageNumber, request.Params.PageSize));
            }
        }
    }
}