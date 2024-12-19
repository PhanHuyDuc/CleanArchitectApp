using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WebsiteInfors
{
    public class Details
    {
        public class Query : IRequest<Result<WebsiteInforDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<WebsiteInforDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<WebsiteInforDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var webInfo = await _context.WebsiteInfors.ProjectTo<WebsiteInforDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<WebsiteInforDto>.Success(webInfo);
            }
        }
    }
}