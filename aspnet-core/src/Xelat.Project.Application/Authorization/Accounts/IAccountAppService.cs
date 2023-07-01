using System.Threading.Tasks;
using Abp.Application.Services;
using Xelat.Project.Authorization.Accounts.Dto;

namespace Xelat.Project.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
