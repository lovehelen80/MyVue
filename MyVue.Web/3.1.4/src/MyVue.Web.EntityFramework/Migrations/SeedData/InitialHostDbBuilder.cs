using MyVue.Web.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyVue.Web.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly WebDbContext _context;

        public InitialHostDbBuilder(WebDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
