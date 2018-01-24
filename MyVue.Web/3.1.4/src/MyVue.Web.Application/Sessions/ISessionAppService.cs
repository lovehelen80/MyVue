using System.Threading.Tasks;
using Abp.Application.Services;
using MyVue.Web.Sessions.Dto;

namespace MyVue.Web.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
