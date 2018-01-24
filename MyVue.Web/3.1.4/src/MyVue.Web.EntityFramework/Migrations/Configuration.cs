using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MyVue.Web.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using MyVue.Web.EntityFramework;

namespace MyVue.Web.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Web.EntityFramework.WebDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Web";
        }

        protected override void Seed(Web.EntityFramework.WebDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
                new DefaultBillTypeCreator(context).Create();// 添加自己初始数据执行
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
