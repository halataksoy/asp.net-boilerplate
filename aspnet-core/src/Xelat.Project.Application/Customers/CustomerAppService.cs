using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Xelat.Project.Authorization;
using Xelat.Project.Customers.Dto;
using Xelat.Project.Customers.Inputs;
using Xelat.Project.Products;
using Xelat.Project.Products.Dto;

namespace Xelat.Project.Customers;

public interface ICustomerAppService : IAsyncCrudAppService<CustomerDto,int, CustomerGetAllInput, CustomerDto, CustomerUpdateDto>
{
}
[AbpAuthorize]
public class CustomerAppService : AsyncCrudAppService<customer, CustomerDto, int, CustomerGetAllInput, CustomerDto, CustomerUpdateDto> , ICustomerAppService
{
    public readonly IProductDomainService _ProductDomainService;
    public CustomerAppService(IRepository<customer, int> repository) : base(repository)
    {
        GetPermissionName = PermissionNames.Pages_Customers;
        CreatePermissionName = PermissionNames.Pages_Customers_Create;
        UpdatePermissionName = PermissionNames.Pages_Customers_Update;
        DeletePermissionName = PermissionNames.Pages_Customers_Delete;
        GetAllPermissionName = PermissionNames.Pages_Customers_GetAll;
    }
    
    protected override IQueryable<customer> CreateFilteredQuery(CustomerGetAllInput input)
    {
        return base.CreateFilteredQuery(input)
            .WhereIf(!string.IsNullOrEmpty(input.Name), a=>a.Name.Contains(input.Name))
            .WhereIf(!string.IsNullOrEmpty(input.Surname), a=>a.Surname.Contains(input.Surname));
    }

    public async Task GetDeletedCustomers()
    {
        var q = Repository.GetAll().Where(a => a.IsDeleted);
        if (AbpSession.MultiTenancySide == MultiTenancySides.Host)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant, AbpDataFilters.MustHaveTenant,
                       AbpDataFilters.SoftDelete))
            {
                var customers = await q.ToListAsync();
            }
        }
        else
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var customers = await q.ToListAsync();
            }
        }
    }

    public async Task<List<ProductDto>> GetDeletedCustomers(EntityDto<int> input)
    {
        var products = await _ProductDomainService.GetCustomerProduct(input.Id,AbpSession.MultiTenancySide);
        var result = ObjectMapper.Map<List<ProductDto>>(products);
        return result;
    }
    
    public async CreateCustomerAndProduct
    //Tenantin hangi customerin bilgilerini sildigini host goruntuleyebilsin
    //customer yonetimi tenantlara aittir tenant sadece kendi sildigi customeri gorsun ancak host hepsini gorecek bir use case 
    //
    //public override async Task<CustomerDto> CreateAsync(CustomerDto input)
    //{
    //    var x = await base.CreateAsync(input);
       //musteri ekleniyor, eklenen musteriye urunler ekleniyor

    //   await CurrentUnitOfWork.SaveChangesAsync();
    // return x;
    //}
  
}
