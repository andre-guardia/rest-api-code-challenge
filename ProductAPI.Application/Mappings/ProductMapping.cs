using AutoMapper;
using ProductAPI.Domain.DTO;
using ProductAPI.Domain.Models;

namespace ProductAPI.Application.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();
        }
    }
}
