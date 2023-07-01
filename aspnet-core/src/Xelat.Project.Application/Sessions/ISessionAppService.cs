using System.Threading.Tasks;
using Abp.Application.Services;
using Xelat.Project.Sessions.Dto;

namespace Xelat.Project.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
