using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Authors
{
    public class Details
    {
        public class Query : IRequest<Result<AuthorDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AuthorDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AuthorDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var author = await _context.Authors.ProjectTo<AuthorDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<AuthorDto>.Success(author);
            }
        }
    }
}