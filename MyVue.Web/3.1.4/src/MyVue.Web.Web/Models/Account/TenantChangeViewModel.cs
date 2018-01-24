using Abp.AutoMapper;
using MyVue.Web.Sessions.Dto;

namespace MyVue.Web.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}