using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Xelat.Project.Products;

public interface IProductDomainService : IDomainService
{
    Task<List<product>> GetCustomerProduct(int CustomerId,MultiTenancySides sides);
}

public class ProductDomainService : DomainService, IProductDomainService
{
    private readonly IRepository<product> _product;
    private readonly IRepository<ProductMapping> _productMapping;

    public ProductDomainService(IRepository<product> product, IRepository<ProductMapping> productMapping) 
    {
        _product = product;
        _productMapping = productMapping;
    }

    public async Task<List<product>> GetCustomerProduct(int CustomerId, MultiTenancySides sides)
    {
        var q = _productMapping.GetAll()
            .Where(a => a.CustomerId.HasValue && a.CustomerId == CustomerId);
        int[] productIds;
        if (sides == MultiTenancySides.Host)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                productIds = await q.Select(a => a.ProductId).ToArrayAsync();
            }
        }
        else
        {
            productIds = await q.Select(a => a.ProductId).ToArrayAsync();
        }

        var products = await _product.GetAll()
            .Where(a => productIds.Contains(a.Id))
            .AsTracking()
            .ToListAsync();

        return products;
    }

}