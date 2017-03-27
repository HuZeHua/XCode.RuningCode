using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IPermissionService
    {
        bool Authorize(string permissionName, UserDto user);

        bool Authorize(string permissionName);
    }
}
