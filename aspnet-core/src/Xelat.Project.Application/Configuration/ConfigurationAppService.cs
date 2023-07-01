using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Xelat.Project.Configuration.Dto;

namespace Xelat.Project.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
