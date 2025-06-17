using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CancelOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (order is not null)
                _applicationDbContext.Orders.Remove(order);
            
            if (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0) return true;
            return false; 
        }
    }
}