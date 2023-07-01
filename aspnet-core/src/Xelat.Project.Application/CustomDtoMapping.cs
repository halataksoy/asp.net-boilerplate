using AutoMapper;
using Xelat.Project.Products;
using Xelat.Project.Products.Dto;

namespace Xelat.Project;

internal static class CustomDtoMapping
{
    public static void CreateMappings(IMapperConfigurationExpression configurationExpression)
    {
        configurationExpression.CreateMap<ProductDto, product >().ReverseMap();
    }

}