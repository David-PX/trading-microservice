using AutoMapper;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UseCases.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<GetOrderResponseDto, Order>().ReverseMap();
            CreateMap<GetAllOrderResponseDto, Order>().ReverseMap();
        }
    }
}