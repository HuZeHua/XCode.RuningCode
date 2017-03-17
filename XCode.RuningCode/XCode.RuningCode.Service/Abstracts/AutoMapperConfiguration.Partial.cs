using AutoMapper;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
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
			Mapper.CreateMap<EmailPoolEntity, EmailPoolDto>();
			Mapper.CreateMap<EmailPoolDto, EmailPoolEntity>();
			Mapper.CreateMap<EmailReceiverEntity, EmailReceiverDto>();
			Mapper.CreateMap<EmailReceiverDto, EmailReceiverEntity>();
			Mapper.CreateMap<LoginLogEntity, LoginLogDto>();
			Mapper.CreateMap<LoginLogDto, LoginLogEntity>();
			Mapper.CreateMap<MenuEntity, MenuDto>();
			Mapper.CreateMap<MenuDto, MenuEntity>();
			Mapper.CreateMap<PageViewEntity, PageViewDto>();
			Mapper.CreateMap<PageViewDto, PageViewEntity>();
			Mapper.CreateMap<RoleEntity, RoleDto>();
			Mapper.CreateMap<RoleDto, RoleEntity>();
			Mapper.CreateMap<RoleMenuEntity, RoleMenuDto>();
			Mapper.CreateMap<RoleMenuDto, RoleMenuEntity>();
			Mapper.CreateMap<UserEntity, UserDto>();
			Mapper.CreateMap<UserDto, UserEntity>();
			Mapper.CreateMap<UserRoleEntity, UserRoleDto>();
			Mapper.CreateMap<UserRoleDto, UserRoleEntity>();
        }
    }
}
