using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyVue.Web.EntityFramework;

namespace MyVue.Web.Migrator
{
    [DependsOn(typeof(WebDataModule))]
    public class WebMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<WebDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}