using System.Threading.Tasks;
using Xelat.Project.Configuration.Dto;

namespace Xelat.Project.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
