using System.Collections.Generic;
using Xelat.Project.Roles.Dto;

namespace Xelat.Project.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
