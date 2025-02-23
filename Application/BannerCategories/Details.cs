using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BannerCategories
{
    public class Details
    {
        public class Query : IRequest<Result<BannerCatDto>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<BannerCatDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<BannerCatDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bannerCat = await _context.BannerCategories.ProjectTo<BannerCatDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<BannerCatDto>.Success(bannerCat);
            }
        }
    }
}