using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder
{
    public sealed record GetOrderQuery : IRequest<GetOrderResponseDto>
    {
        public int Id { get; set; }
    }
}