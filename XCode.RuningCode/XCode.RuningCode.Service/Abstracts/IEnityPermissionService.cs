using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IEnityPermissionService
    {
        bool Authorize<T>(T entity) where T : BaseEntity;
    }
}