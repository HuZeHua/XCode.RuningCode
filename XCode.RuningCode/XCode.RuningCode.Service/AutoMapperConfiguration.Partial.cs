using AutoMapper;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

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
			Mapper.CreateMap<PageView, PageViewDto>();
			Mapper.CreateMap<PageViewDto, PageView>();
			Mapper.CreateMap<Role, RoleDto>();
			Mapper.CreateMap<RoleDto, Role>();
			Mapper.CreateMap<User, UserDto>();
			Mapper.CreateMap<UserDto, User>();
			Mapper.CreateMap<PermissionDto, Permission>();
			Mapper.CreateMap<CategoryDto, Category>();
			Mapper.CreateMap<NavigateDto, Navigate>();

            Mapper.CreateMap<ArticleDto, Article>();
            Mapper.CreateMap<ArticleSettingDto, ArticleSetting>();
            Mapper.CreateMap<SiteSettingDto, SiteSetting>();
            Mapper.CreateMap<TagDto, Tag>();
            Mapper.CreateMap<CommentDto, Comment>();
            Mapper.CreateMap<VoteDto, Vote>();
            Mapper.CreateMap<FriendlyLinkDto, FriendlyLink>();
            Mapper.CreateMap<NoticeDto, Notice>();
        }
    }
}
