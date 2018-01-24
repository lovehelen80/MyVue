using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyVue.Web.Configuration.Dto;

namespace MyVue.Web.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WebAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
