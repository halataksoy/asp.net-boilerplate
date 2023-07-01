using System.Collections.Generic;
using Xelat.Project.Roles.Dto;

namespace Xelat.Project.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}