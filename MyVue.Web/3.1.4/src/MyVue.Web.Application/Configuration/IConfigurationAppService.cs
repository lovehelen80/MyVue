using System.Threading.Tasks;
using Abp.Application.Services;
using MyVue.Web.Configuration.Dto;

namespace MyVue.Web.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}