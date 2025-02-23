using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Contents
{
    public class Details
    {
        public class Query : IRequest<Result<ContentDto>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<ContentDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ContentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var content = await _context.Contents.ProjectTo<ContentDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<ContentDto>.Success(content);
            }
        }
    }
}