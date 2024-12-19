using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ContentCategories
{
    public class Details
    {
        public class Query : IRequest<Result<ContentCatDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<ContentCatDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ContentCatDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var contentCat = await _context.ContentCategories.ProjectTo<ContentCatDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<ContentCatDto>.Success(contentCat);
            }
        }
    }
}