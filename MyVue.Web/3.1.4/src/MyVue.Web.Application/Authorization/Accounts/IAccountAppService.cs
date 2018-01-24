using System.Threading.Tasks;
using Abp.Application.Services;
using MyVue.Web.Authorization.Accounts.Dto;

namespace MyVue.Web.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
