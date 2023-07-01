using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Xelat.Project.Products.Dto;

public class ProductDto : EntityDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
}