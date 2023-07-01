using Abp.AspNetCore.Mvc.ViewComponents;

namespace Xelat.Project.Web.Views
{
    public abstract class ProjectViewComponent : AbpViewComponent
    {
        protected ProjectViewComponent()
        {
            LocalizationSourceName = ProjectConsts.LocalizationSourceName;
        }
    }
}
