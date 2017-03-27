using System.Collections.Generic;
using XCode.RuningCode.Entity;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();
    }
}
