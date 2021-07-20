using AutoMapper;
using Order.Application.Features.Orders.Commands.CheckoutOrder;
using Order.Application.Features.Orders.Commands.UpdateOrder;
using Order.Application.Features.Orders.Queries.GetOrderList;
using Order.Domain.Models;

namespace Order.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, OrdersVm>().ReverseMap();
            CreateMap<OrderModel, CheckoutOrderCommand>().ReverseMap();
            CreateMap<OrderModel, UpdateOrderCommand>().ReverseMap();
        }
    }
}
