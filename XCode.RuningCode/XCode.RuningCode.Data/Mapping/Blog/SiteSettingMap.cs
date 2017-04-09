using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class SiteSettingMap : EntityTypeConfiguration<SiteSetting>
    {
        public SiteSettingMap()
        {
            this.HasKey(p => p.Id);
        }
    }
}