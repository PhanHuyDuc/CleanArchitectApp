using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BannerCategories
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public BannerCategory BannerCategory { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var bannerCat = await _context.BannerCategories.FindAsync(request.BannerCategory.Id);
                if (bannerCat == null) return null;
                _mapper.Map(request.BannerCategory, bannerCat);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed when Update Banner Category");
            }
        }
    }
}