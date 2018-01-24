using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using MyVue.Web.Authorization.Roles;
using MyVue.Web.Authorization.Users;
using MyVue.Web.Bills;
using MyVue.Web.MultiTenancy;

namespace MyVue.Web.EntityFramework
{
    public class WebDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WebDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WebDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WebDbContext since ABP automatically handles it.
         */
        public WebDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WebDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public WebDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        public IDbSet<Bill> Bills { get; set; } // 账单数据集
        public IDbSet<BillType> BillTypes { get; set; } // 记账类型数据集
    }
}
