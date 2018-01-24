using Abp.Authorization;
using MyVue.Web.Authorization.Roles;
using MyVue.Web.Authorization.Users;

namespace MyVue.Web.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
