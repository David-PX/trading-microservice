using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<GetAllOrderResponseDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllOrderResponseDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.ToListAsync(cancellationToken);
            var response = _mapper.Map<IEnumerable<GetAllOrderResponseDto>>(order);
            return response;
        }
    }
}