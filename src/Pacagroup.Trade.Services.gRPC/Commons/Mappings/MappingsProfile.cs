using AutoMapper;
using Google.Protobuf.WellKnownTypes;

using Pacagroup.Trade.Services.gRPC.Protos;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CancelOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;

namespace Pacagroup.Trade.Services.gRPC.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));

            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<CreateOrderCommand, CreateOrderRequest>().ReverseMap();
            CreateMap<UpdateOrderCommand, UpdateOrderRequest>().ReverseMap();
            CreateMap<OrderResponse, GetOrderResponseDto>().ReverseMap();
            CreateMap<OrderResponse, GetAllOrderResponseDto>().ReverseMap();
        }
    }
}