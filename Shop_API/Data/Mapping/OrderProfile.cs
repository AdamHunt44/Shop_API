using AutoMapper;
using Shop_API.Data.Entities;
using Shop_API.Model;

namespace Shop_API.Data.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<OrderModel, Order>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.OrderId))
                .ReverseMap();

            this.CreateMap<OrderItem, OrderItemModel>()
                .ReverseMap();
        }
    }
}