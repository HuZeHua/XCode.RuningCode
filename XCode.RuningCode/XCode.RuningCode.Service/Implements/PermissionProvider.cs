using System.Collections.Generic;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Service.Implements
{
    public class PermissionProvider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            var permissions = new List<Permission>
                              {
                                  new Permission { Name = "ManagerList", Category = "后台管理", Description = "列表" }
                              };
            return permissions;
        }
    }
}