using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Xelat.Project.Authorization;

namespace Xelat.Project
{
    [DependsOn(
        typeof(ProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProjectAuthorizationProvider>();
            //adding custom automapper configuration 
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapping.CreateMappings);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
