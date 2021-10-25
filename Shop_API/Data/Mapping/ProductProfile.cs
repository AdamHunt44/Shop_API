using AutoMapper;
using Shop_API.Data.Entities;

namespace Shop_API.Model.Mapping
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