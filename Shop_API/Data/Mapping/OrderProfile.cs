using AutoMapper;
using Shop_API.Data.Entities;
using Shop_API.Model;

namespace Shop_API.Data.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            this.CreateMap<OrderItem, OrderItemModel>()
                .ReverseMap();
        }
    }
}