using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IAuthorizeProvider
    {
        void SignIn(UserDto user, bool rememberMe);

        void SignOut();

        UserDto GetAuthorizeUser();
    }
}
