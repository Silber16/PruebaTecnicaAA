using AutoMapper;
using Domain.Entities;
using AppCore.DTOs;

namespace AppCore.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Product -> ProductDTO (GET)
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryDescription,
                           opt => opt.MapFrom(src => src.CategoryProduct.CategoryDescription));

            // CreateProductDTO - Product (UPDATE/CREATE)
            CreateMap<CreateProductDTO, Product>();

            // ProductCategory - ProductCategoryDTO
            CreateMap<ProductCategory, ProductCategoryDTO>();

            // Bidireccional
            CreateMap<ProductDTO, Product>();

            CreateMap<CreateProductDTO, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription))
            .ForMember(dest => dest.CategoryProductId, opt => opt.MapFrom(src => src.CategoryProductId))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.HaveECDiscount, opt => opt.MapFrom(src => src.HaveECDiscount))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));


            CreateMap<ProductCategoryDTO, ProductCategory>();
        }
    }
}
