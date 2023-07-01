using Abp.Authorization;
using Xelat.Project.Authorization.Roles;
using Xelat.Project.Authorization.Users;

namespace Xelat.Project.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
