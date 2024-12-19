using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.MenuCategories
{
    public class Details
    {
        public class Query : IRequest<Result<MenuCategoryDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<MenuCategoryDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<MenuCategoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var menuCat = await _context.MenuCategories.ProjectTo<MenuCategoryDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.Id == request.Id);
                return Result<MenuCategoryDto>.Success(menuCat);
            }
        }
    }
}