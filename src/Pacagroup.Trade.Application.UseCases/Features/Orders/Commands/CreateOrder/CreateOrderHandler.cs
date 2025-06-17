using AutoMapper;
using MediatR;
using Pacagroup.Trade.Application.Persistence;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _applicationDbContext.Orders.AddAsync(order, cancellationToken);

            if (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0) return true;
            return false;
        }
    }
}