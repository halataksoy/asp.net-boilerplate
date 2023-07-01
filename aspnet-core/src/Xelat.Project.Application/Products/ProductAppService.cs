using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Xelat.Project.Authorization;
using Xelat.Project.Products.Dto;
using Xelat.Project.Products.Inputs;

namespace Xelat.Project.Products;

public interface IProductAppService : IApplicationService
{
    Task<ProductDto> CreateOrUpdate(ProductDto input);
    Task<List<ProductDto>> getCustomerProduct(CustomerProductInput input);
    Task<PagedResultDto<List<ProductDto>>> GetAll(ProductGetAllInput input);
    Task<List<ProductDto>> GetDeletedCustomers(EntityDto<int> input);
}

/// <inheritdoc />
[AbpAuthorize(PermissionNames.Pages_Products_)]
public class ProductAppService : ApplicationService, IProductAppService
{
    private readonly IProductDomainService _ProductDomainService;
    private readonly IRepository<product> _product;
    private readonly IRepository<ProductMapping> _productmapping;

    public ProductAppService(IRepository<product> product, IRepository<ProductMapping> productmapping, IProductDomainService productDomainService)
    {
        _product = product;
        _productmapping = productmapping;
        _ProductDomainService = productDomainService;
    }
    [AbpAuthorize(PermissionNames.Pages_Products_CustomerProduct)]
    public async Task<List<ProductDto>> getCustomerProduct(CustomerProductInput input)
    {
        var CustomerProducts = await _productmapping.GetAll().Where(a =>a.CustomerId.HasValue && a.CustomerId == input.CustomerId).ToListAsync();

        var productIds = CustomerProducts.Select(a => a.CustomerId.Value).ToArray();

        var products = await _product.GetAll().Where(a => productIds.Contains(a.Id)).ToListAsync();

        var result = ObjectMapper.Map<List<ProductDto>>(products);

        return result;
    }
    public async Task <PagedResultDto<List<ProductDto>>> GetAll(ProductGetAllInput input)
    {


        var q = _product.GetAll().OrderBy(!string.IsNullOrEmpty(input.Sorting) ? input.Sorting : "name asc")
            .WhereIf(input.MinPrice.HasValue, a => a.Price >= input.MinPrice.Value && a.Price <= input.MaxPrice.Value)
            .WhereIf(!string.IsNullOrEmpty(input.Name), a => a.Name.Contains(input.Name))
            .WhereIf(input.ProductId.HasValue, a => a.Id == input.ProductId.Value);
        var TotalCount = q.Count();

            var products = await q.Skip(input.SkipCount).Take(input.MaxResultCount).ToDynamicListAsync();

            var productDto = ObjectMapper.Map<IReadOnlyList<List<ProductDto>>>(products);

            var result = new PagedResultDto<List<ProductDto>>()
            {
              Items = (IReadOnlyList<List<ProductDto>>)new []{productDto},
              TotalCount   = TotalCount,
            };
            return result;
    }
    
    public async Task<List<ProductDto>> GetDeletedCustomers(EntityDto<int> input)
    {
        var products = await _ProductDomainService.GetCustomerProduct(input.Id, AbpSession.MultiTenancySide);
        var result = ObjectMapper.Map<List<ProductDto>>(products);
        return result;
    }

    public async Task<ProductDto> CreateOrUpdate(ProductDto input)
    {
        var p = ObjectMapper.Map<product>(input);
        var product = await _product.InsertOrUpdateAsync(p);

        var dto = ObjectMapper.Map<ProductDto>(product);
        return dto;
    }
}