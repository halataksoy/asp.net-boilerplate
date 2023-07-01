using System.Collections.Generic;
using System.Linq;
using Xelat.Project.Roles.Dto;
using Xelat.Project.Users.Dto;

namespace Xelat.Project.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
