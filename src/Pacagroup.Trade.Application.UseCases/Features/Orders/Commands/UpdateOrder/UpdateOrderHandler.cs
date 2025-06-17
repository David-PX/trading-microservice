using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateOrderHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (order is not null)
            {
                order.Quanty = request.Quanty;
                order.Type = (Domain.Enums.OrderType)request.Type;
                order.Price = request.Price;
                order.Text = request.Text;

                _applicationDbContext.Orders.Update(order);
            }

            if (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0) return true;
            return false;            
        }
    }
}