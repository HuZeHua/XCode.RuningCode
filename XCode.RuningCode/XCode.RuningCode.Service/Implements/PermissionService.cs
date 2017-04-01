using System;
using System.Linq;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    public class PermissionService : IPermissionService
    {
        private readonly IAuthorizeProvider provider;
        private IRepository<Permission> repository;

        public PermissionService(IAuthorizeProvider provider, IRepository<Permission> repository)
        {
            this.provider = provider;
            this.repository = repository;
        }

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