using System.Data.Entity.ModelConfiguration;
using XCode.RuningCode.Entity.Blog;

namespace XCode.RuningCode.Data.Mapping.Blog
{
    public partial class ArticleSettingMap : EntityTypeConfiguration<ArticleSetting>
    {
        public ArticleSettingMap()
        {
            this.HasKey(p => p.Id);
        }
    }
}