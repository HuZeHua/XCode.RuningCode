using AutoMapper;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service
{
    /// <summary>
    /// AutoMapper 配置
    /// </summary>
    public partial class AutoMapperConfiguration
    {
        /// <summary>
        /// 配置AutoMapper
        /// </summary>
        public static void Config()
        {
			Mapper.CreateMap<EmailPool, EmailPoolDto>();
			Mapper.CreateMap<EmailPoolDto, EmailPool>();
			Mapper.CreateMap<EmailReceiver, EmailReceiverDto>();
			Mapper.CreateMap<EmailReceiverDto, EmailReceiver>();
			Mapper.CreateMap<LoginLog, LoginLogDto>();
			Mapper.CreateMap<LoginLogDto, LoginLog>();
			Mapper.CreateMap<Menu, MenuDto>();
			Mapper.CreateMap<MenuDto, Menu>();
			Mapper.CreateMap<PageView, PageViewDto>();
			Mapper.CreateMap<PageViewDto, PageView>();
			Mapper.CreateMap<Role, RoleDto>();
			Mapper.CreateMap<RoleDto, Role>();
			Mapper.CreateMap<RoleMenu, RoleMenuDto>();
			Mapper.CreateMap<RoleMenuDto, RoleMenu>();
			Mapper.CreateMap<User, UserDto>();
			Mapper.CreateMap<UserDto, User>();
			Mapper.CreateMap<UserRole, UserRoleDto>();
			Mapper.CreateMap<UserRoleDto, UserRole>();
        }
    }
}
