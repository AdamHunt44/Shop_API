using Shop_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Shop_API.Model
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductModel>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.ProductId))
                .ReverseMap();
        }
    }
}
