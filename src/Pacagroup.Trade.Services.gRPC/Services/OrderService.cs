using AutoMapper;
using Grpc.Core;
using MediatR;
using Pacagroup.Trade.Services.gRPC.Protos;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CancelOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Command.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;


namespace Pacagroup.Trade.Services.gRPC.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<GetAllOrderResponse> GetAllOrder(GetAllOrderRequest getAllOrderRequest, ServerCallContext context)
        {
            var ordersDto = await _mediator.Send(new GetAllOrderQuery());
            var response = new GetAllOrderResponse();
            var serverResponse = new ServerResponse();

            if (ordersDto.Any())
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Success Query";
                response.Data.AddRange(_mapper.Map<IEnumerable<OrderResponse>>(ordersDto));
            }
            else
                serverResponse.Message = "Orders not founded";

            response.ServerResponse = serverResponse;
            return response;
        }

        public override async Task<GetOrderResponse> GetOrder(GetOrderRequest getOrderRequest, ServerCallContext context)
        {
            var orderDto = await _mediator.Send(new GetOrderQuery()
            {
                Id = getOrderRequest.Id
            });

            var response = new GetOrderResponse();
            var serverResponse = new ServerResponse();

            if (orderDto is null)
            {
                serverResponse.Message = $"Order {getOrderRequest.Id} Not found";
            }

            response.Data = _mapper.Map<OrderResponse>(orderDto);
            serverResponse.IsSuccess = true;
            serverResponse.Message = "Query Success";

            response.ServerResponse = serverResponse;
            return response;
        }

        public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrderRequest, ServerCallContext context)
        {
            var createOrderCommand = _mapper.Map<CreateOrderCommand>(createOrderRequest);
            var status = await _mediator.Send(createOrderCommand);
            var response = new CreateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var orderDto = await _mediator.Send(new GetOrderQuery() { Id = createOrderRequest.Id });

                response.Data = _mapper.Map<OrderResponse>(orderDto);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Insert Successfull";
            }
            else
                serverResponse.Message = $"Errors creating order #: {createOrderRequest.Id}";

            response.ServerResponse = serverResponse;
            return response;
        }

        public override async Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest updateOrderRequest, ServerCallContext context)
        {
            var updateOrderCommand = _mapper.Map<UpdateOrderCommand>(updateOrderRequest);
            var status = await _mediator.Send(updateOrderCommand);
            var response = new UpdateOrderResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                var orderDto = await _mediator.Send(new GetOrderQuery() { Id = updateOrderRequest.Id });

                response.Data = _mapper.Map<OrderResponse>(orderDto);
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Updated Successfull";
            }
            else
                serverResponse.Message = $"Errors updating order #: {updateOrderRequest.Id}";

            response.ServerResponse = serverResponse;
            return response;
        }
        
        public override async Task<CancelOrderResponse> CancelOrder(CancelOrderRequest cancelOrderRequest, ServerCallContext context)
        {
            var status = await _mediator.Send(new CancelOrderCommand() { Id = cancelOrderRequest.Id });
            var response = new CancelOrderResponse();
            var serverResponse = new ServerResponse();

            if (status)
            {
                serverResponse.IsSuccess = true;
                serverResponse.Message = "Cancel Successfull";
            }
            else
                serverResponse.Message = $"Errors updating order #: {cancelOrderRequest. Id}";

            response.ServerResponse = serverResponse;
            return response;
        }
    }
}