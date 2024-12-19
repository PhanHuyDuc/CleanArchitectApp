using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Banners
{
    public class Details
    {
        public class Query : IRequest<Result<BannerDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<BannerDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<BannerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var banner = await _context.Banners.ProjectTo<BannerDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<BannerDto>.Success(banner);
            }
        }
    }
}