using Abp.Application.Services;
using Xelat.Project.MultiTenancy.Dto;

namespace Xelat.Project.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

