using AutoMapper;
using Shop_API.Data.Entities;
using Shop_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Data
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
