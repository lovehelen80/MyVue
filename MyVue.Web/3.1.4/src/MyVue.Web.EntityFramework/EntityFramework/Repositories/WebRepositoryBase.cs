using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyVue.Web.EntityFramework.Repositories
{
    public abstract class WebRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WebDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WebRepositoryBase(IDbContextProvider<WebDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WebRepositoryBase<TEntity> : WebRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WebRepositoryBase(IDbContextProvider<WebDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
