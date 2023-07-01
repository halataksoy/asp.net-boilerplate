using System.Collections.Generic;
using Xelat.Project.Roles.Dto;

namespace Xelat.Project.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
