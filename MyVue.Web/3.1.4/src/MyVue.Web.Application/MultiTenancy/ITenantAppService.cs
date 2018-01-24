using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyVue.Web.MultiTenancy.Dto;

namespace MyVue.Web.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
