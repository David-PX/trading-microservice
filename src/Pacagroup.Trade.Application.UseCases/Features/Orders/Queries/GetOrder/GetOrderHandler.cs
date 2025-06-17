using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderResponseDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<GetOrderResponseDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var response = _mapper.Map<GetOrderResponseDto>(order);
            return response;
        }
    }
}