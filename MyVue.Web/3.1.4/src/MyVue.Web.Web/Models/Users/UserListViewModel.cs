using System.Collections.Generic;
using MyVue.Web.Roles.Dto;
using MyVue.Web.Users.Dto;

namespace MyVue.Web.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}