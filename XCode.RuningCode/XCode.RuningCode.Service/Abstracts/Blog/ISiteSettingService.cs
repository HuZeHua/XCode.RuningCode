using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface ISiteSettingService
    {
        SiteSettingDto GetSiteSetting();
        void Update(SiteSettingDto entity);
    }
}
