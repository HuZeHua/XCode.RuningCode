using System;
using System.Linq;
using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    public class PermissionService : IPermissionService
    {
        private readonly IAuthorizeProvider provider;

        public PermissionService(IAuthorizeProvider provider)
        {
            this.provider = provider;
        }

        private XCodeContext db = new XCodeContext();

        public bool Authorize(string permissionName)
        {
            return Authorize(permissionName, provider.GetAuthorizeUser());
        }

        public bool Authorize(string permissionName, UserDto user)
        {
            return user.Roles.Where(role => role.Active).Any(role => Authorize(permissionName, role));
        }

        protected virtual bool Authorize(string permissionName, RoleDto role)
        {
            return role.Permissions.Any(p => p.Name.Equals(permissionName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}