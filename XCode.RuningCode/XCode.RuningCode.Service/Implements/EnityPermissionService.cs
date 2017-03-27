using XCode.RuningCode.Data.Data;
using XCode.RuningCode.Entity.Base;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Service.Implements
{
    public class EnityPermissionService : IEnityPermissionService
    {
        private XCodeContext db = new XCodeContext();



        public bool Authorize<T>(T entity) where T : BaseEntity
        {
            var roleIds = WorkContext.CurrentUser.Roles.Select(r => r.ID);
            return db.EntityPermissions.Any(ep => ep.EntityName == typeof(T).Name && ep.EntityID == entity.ID && roleIds.Contains(ep.RoleID));
        }
    }
}